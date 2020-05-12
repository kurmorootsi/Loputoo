using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
	public Image icon;

	Object item;

	public void AddItem (Object newItem)
	{
		item = newItem;

		icon.sprite = item.icon;
		icon.enabled = true;
	}

	public void ClearSlot ()
	{
		item = null;

		icon.sprite = null;
		item.enabled = false;
	}
}
