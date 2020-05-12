using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	public List<Object> items = new List<Object>();

	public bool Add (Object item)
	{
		if (items.Count >= space)
		{
			return false;
		}
		items.Add(item);

		if (onItemChangedCallback != null)
		{
			onItemChangedCallback.Invoke();
		}

		return true;
	}

	public void Remove (Object item)
	{
		items.Remove(item);

		if (onItemChangedCallback != null)
		{
			onItemChangedCallback.Invoke();
		}
	}

}
