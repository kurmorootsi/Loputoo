using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
	#region Singleton

	public static Inventory instance;

	private void Awake()
	{
		if (instance != null)
		{
			return;
		}
		instance = this;
	}

	#endregion

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public int space = 5;

	[SerializeField]
	public TMPro.TextMeshProUGUI timer;

	float timeLeft = 120f;

	[SerializeField]
	public LevelManagerObject levelManager;

	public List<DragAndDrop> teacher_items = new List<DragAndDrop>();
	public List<DragAndDrop> student_items = new List<DragAndDrop>();
	public List<DragAndDrop> materjal_items = new List<DragAndDrop>();
	public List<DragAndDrop> klassiruum_items = new List<DragAndDrop>();

	[SerializeField]
	public bool required_teacher_ylem;

	[SerializeField]
	public bool required_student_ylem;

	[SerializeField]
	public int required_teacher;
	[SerializeField]
	public int required_student;
	[SerializeField]
	public int required_materjal;
	[SerializeField]
	public int required_klassiruum;


	[SerializeField]
	public int required_parameeter;

	public int parameeter_count;

	public bool Add (DragAndDrop item, DropDestination destination)
	{
		switch(item.classType)
		{
			case "student":
				if (student_items.Count >= space)
				{
					return false;
				}
				student_items.Add(item);

				Debug.Log(destination.slots.Length);
				Debug.Log(student_items.Count);
				for (int i = 0; i < destination.slots.Length; i++)
				{
					if (i < student_items.Count)
					{
						destination.slots[i].AddItem(student_items[i]);
					}
					else
					{
						destination.slots[i].ClearSlot();
					}
				}

				return true;
			case "teacher":
				if (teacher_items.Count >= space)
				{
					return false;
				}
				teacher_items.Add(item);

				for (int i = 0; i < destination.slots.Length; i++)
				{
					if (i < teacher_items.Count)
					{
						destination.slots[i].AddItem(teacher_items[i]);
					}
					else
					{
						destination.slots[i].ClearSlot();
					}
				}

				return true;
			case "materjal":
				if (materjal_items.Count >= space)
				{
					return false;
				}
				materjal_items.Add(item);

				for (int i = 0; i < destination.slots.Length; i++)
				{
					if (i < materjal_items.Count)
					{
						destination.slots[i].AddItem(materjal_items[i]);
					}
					else
					{
						destination.slots[i].ClearSlot();
					}
				}

				return true;
			case "klassiruum":
				if (klassiruum_items.Count >= space)
				{
					return false;
				}
				klassiruum_items.Add(item);

				for (int i = 0; i < destination.slots.Length; i++)
				{
					if (i < klassiruum_items.Count)
					{
						destination.slots[i].AddItem(klassiruum_items[i]);
					}
					else
					{
						destination.slots[i].ClearSlot();
					}
				}

				return true;
		}

		return false;
	}

	public void Remove (DragAndDrop item)
	{
		Debug.Log(item.classType);
		switch (item.classType)
		{
			case "student":
				student_items.Remove(item);
				break;
			case "teacher":
				teacher_items.Remove(item);
				break;
			case "materjal":
				materjal_items.Remove(item);
				break;
			case "klassiruum":
				klassiruum_items.Remove(item);
				break;
		}

		if (onItemChangedCallback != null)
		{
			onItemChangedCallback.Invoke();
		}
	}

	public void activateUlem(DragAndDrop item)
	{
		switch (item.classType)
		{
			case "student":
				foreach(DragAndDrop objekt in student_items)
				{
					objekt.ulemActive = true;
				}
				break;
			case "teacher":
				foreach (DragAndDrop objekt in student_items)
				{
					objekt.ulemActive = true;
				}
				break;
			case "materjal":
				foreach (DragAndDrop objekt in student_items)
				{
					objekt.ulemActive = true;
				}
				break;
			case "klassiruum":
				foreach (DragAndDrop objekt in student_items)
				{
					objekt.ulemActive = true;
				}
				break;
		}
	}

	private void Start()
	{
		InvokeRepeating("updateTimer", 0, 1.0f);
	}

	public void updateTimer()
	{
		if (timeLeft <= 0)
		{
			finishLevel();
		} else
		{
			timeLeft -= 1;
			timer.text = "" + timeLeft;
		}
	}

	public void finishLevel()
	{
		CancelInvoke("updateTimer");

		int givenStars = 3;
		int fails = 0;

		if (required_klassiruum != klassiruum_items.Count)
		{
			fails++;
		}
		if (required_teacher != teacher_items.Count)
		{
			fails++;
		}
		if (required_student != student_items.Count)
		{
			fails++;
		}
		if (required_materjal != materjal_items.Count)
		{
			fails++;
		}

		if (required_student_ylem)
		{
			if(student_items.Count > 0)
			{
				if (!student_items[0].ulemActive)
				{
					fails++;
				}
			}
		}

		if (required_teacher_ylem)
		{
			if (teacher_items.Count>0)
			{
				if (!teacher_items[0].ulemActive)
				{
					fails++;
				}
			}

		}

		if (required_parameeter != parameeter_count && required_parameeter>0)
		{
			fails++;
		}

		switch (fails)
		{
			case 0:
				givenStars = 3;
				break;
			case 1:
				givenStars = 2;
				break;
			case 2:
				givenStars = 1;
				break;
			case 3:
				givenStars = 1;
				break;
			default:
				givenStars = 0;
				break;
		}

		levelManager.finishLevel(givenStars);
	}


}
