using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropDestination : MonoBehaviour, IDropHandler
{

	[SerializeField]
	private GameObject klassi_info;

	[SerializeField]
	private GameObject ylem_klass_info;
	[SerializeField]
	private GameObject ylem_klass_info_en;

	[SerializeField]
	private GameObject hidden_button;

	[SerializeField]
	private Sprite opetaja_inimene_info;
	[SerializeField]
	private Sprite opetaja_info;
	[SerializeField]
	private Sprite opilane_inimene_info;
	[SerializeField]
	private Sprite opilane_info;
	[SerializeField]
	private Sprite materjal_info;
	[SerializeField]
	private Sprite klassiruum_info;

	[SerializeField]
	private Sprite opetaja_inimene_info_en;
	[SerializeField]
	private Sprite opetaja_info_en;
	[SerializeField]
	private Sprite opilane_inimene_info_en;
	[SerializeField]
	private Sprite opilane_info_en;
	[SerializeField]
	private Sprite materjal_info_en;
	[SerializeField]
	private Sprite klassiruum_info_en;

	Inventory inventory;
	public InventorySlot[] slots;

	private int items = 0;

	private int add_left = 2;

	[SerializeField]
	private GameObject tyhi_koht;

	[SerializeField]
	private GameObject klass_koht;

	[SerializeField]
	private Image dropped_class_image;

	[SerializeField]
	private GameObject dropped_class;

	[SerializeField]
	private DragAndDrop last_dropped_object;

	[SerializeField]
	private DragAndDrop dropped_drag;

	[SerializeField]
	private string drag_classtype = "";

	[SerializeField]
	public LevelManagerObject LevelManagerObject;

	[SerializeField]
	public Transform itemsParent;

	public bool ulemActive = false;

	[SerializeField]
	public DragAndDrop student_prefab;
	[SerializeField]
	public DragAndDrop teacher_prefab;
	[SerializeField]
	public DragAndDrop klassiruum_prefab;
	[SerializeField]
	public DragAndDrop materjal_prefab;

	[SerializeField]
	public Sprite klass_koht_ulem;

	public bool is_tyhi = true;

	public void addNew()
	{
		if (add_left < 1)
		{
			return;
		}
		add_left--;
		switch (dropped_drag.classType)
		{
			case "student":
				DragAndDrop newItemStudent = Instantiate(student_prefab);
				inventory.Add(newItemStudent, this);
				break;
			case "teacher":
				DragAndDrop newItemTeacher = Instantiate(teacher_prefab);
				inventory.Add(newItemTeacher, this);
				break;
			case "materjal":
				DragAndDrop newItemMaterjal = Instantiate(materjal_prefab);
				inventory.Add(newItemMaterjal, this);
				break;
			case "klassiruum":
				DragAndDrop newItemKlassiruum = Instantiate(klassiruum_prefab);
				inventory.Add(newItemKlassiruum, this);
				break;
		}
	}

	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.pointerDrag != null)
		{
			Debug.Log("smth dropped");
			DragAndDrop droppedItem = eventData.pointerDrag.GetComponent<DragAndDrop>();
			if (!droppedItem.isObject && is_tyhi && !droppedItem.isPara)
			{
				Debug.Log("klass dropped");
				drag_classtype = droppedItem.classType;
				dropped_drag = droppedItem;
				is_tyhi = false;
				dropped_drag.droppedOnDestination = true;
				dropped_drag.draggable = false;

				switch(dropped_drag.classType)
				{
					case "student":
						if (PlayerPrefs.GetInt("_language_index") == 0)
						{
							klassi_info.GetComponent<Image>().sprite = opilane_info;
						} else
						{
							klassi_info.GetComponent<Image>().sprite = opilane_info_en;
						}
						break;
					case "teacher":
						if (PlayerPrefs.GetInt("_language_index") == 0)
						{
							klassi_info.GetComponent<Image>().sprite = opetaja_info;
						}
						else
						{
							klassi_info.GetComponent<Image>().sprite = opetaja_info_en;
						}
						
						break;
					case "materjal":
						if (PlayerPrefs.GetInt("_language_index") == 0)
						{
							klassi_info.GetComponent<Image>().sprite = materjal_info;
						}
						else
						{
							klassi_info.GetComponent<Image>().sprite = materjal_info_en;
						}
						break;
					case "klassiruum":
						if (PlayerPrefs.GetInt("_language_index") == 0)
						{
							klassi_info.GetComponent<Image>().sprite = klassiruum_info;
						}
						else
						{
							klassi_info.GetComponent<Image>().sprite = klassiruum_info_en;
						}
						break;
				}

				dropped_class = dropped_drag.gameObject;
				dropped_class_image.gameObject.SetActive(true);
				dropped_class_image.sprite = dropped_drag.sprite;

				tyhi_koht.SetActive(false);
				klass_koht.SetActive(true);
				dropped_class.SetActive(false);

			}
			else if (droppedItem.isObject && !is_tyhi && (dropped_drag.classType == droppedItem.classType))
			{
				Debug.Log("object dropped");
				last_dropped_object = droppedItem;
				if (Inventory.instance.Add(last_dropped_object, this))
				{
					Debug.Log("item added");
					GameObject dropped_object = last_dropped_object.gameObject;
					dropped_object.SetActive(false);
					last_dropped_object.droppedOnDestination = true;
					last_dropped_object.draggable = false;
				}
			}
			else if (droppedItem.classType == "ulem" && !is_tyhi && dropped_drag.canUlem && !ulemActive)
			{
				Debug.Log("ülemklass dropped");
				klass_koht.GetComponent<Image>().sprite = klass_koht_ulem;
				ulemActive = true;

				if (PlayerPrefs.GetInt("_language_index") == 0)
				{
					ylem_klass_info.SetActive(true);
				}
				else
				{
					ylem_klass_info_en.SetActive(true);
				}
				

				switch (dropped_drag.classType)
				{
					case "student":
						if (PlayerPrefs.GetInt("_language_index") == 0)
						{
							klassi_info.GetComponent<Image>().sprite = opilane_inimene_info;
						}
						else
						{
							klassi_info.GetComponent<Image>().sprite = opilane_inimene_info_en;
						}
						break;
					case "teacher":
						if (PlayerPrefs.GetInt("_language_index") == 0)
						{
							klassi_info.GetComponent<Image>().sprite = opetaja_inimene_info;
						}
						else
						{
							klassi_info.GetComponent<Image>().sprite = opetaja_inimene_info_en;
						}
						break;
				}
				hidden_button.SetActive(false);
				Inventory.instance.activateUlem(dropped_drag);
				droppedItem.gameObject.SetActive(false);
			}
			else if ((dropped_drag.classType == droppedItem.classType) && !is_tyhi && droppedItem.isPara)
			{
				Debug.Log("parameeter dropped");
				Inventory.instance.parameeter_count++;
				droppedItem.gameObject.SetActive(false);
			}
		}
	}

	void UpdateUI ()
	{
		if (drag_classtype == "")
		{
			return;
		}
		switch (dropped_drag.classType)
		{
			case "student":
				for (int i = 0; i < slots.Length; i++)
				{
					if (i < inventory.student_items.Count)
					{
						slots[i].AddItem(inventory.student_items[i]);
					}
					else
					{
						slots[i].ClearSlot();
					}
				}
				break;
			case "teacher":
				for (int i = 0; i < slots.Length; i++)
				{
					if (i < inventory.teacher_items.Count)
					{
						slots[i].AddItem(inventory.teacher_items[i]);
					}
					else
					{
						slots[i].ClearSlot();
					}
				}
				break;
			case "materjal":
				for (int i = 0; i < slots.Length; i++)
				{
					if (i < inventory.materjal_items.Count)
					{
						slots[i].AddItem(inventory.materjal_items[i]);
					}
					else
					{
						slots[i].ClearSlot();
					}
				}
				break;
			case "klassiruum":
				for (int i = 0; i < slots.Length; i++)
				{
					if (i < inventory.klassiruum_items.Count)
					{
						slots[i].AddItem(inventory.klassiruum_items[i]);
					}
					else
					{
						slots[i].ClearSlot();
					}
				}
				break;
		}

	}

	private void Start()
	{
		inventory = Inventory.instance;
		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
		inventory.onItemChangedCallback += UpdateUI;
	}

}
