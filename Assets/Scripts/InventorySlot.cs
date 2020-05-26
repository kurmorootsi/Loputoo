using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
	public Image icon;
	public Text text;
	public Button removeButton;

	DragAndDrop item;

	public void AddItem (DragAndDrop newItem)
	{
		item = newItem;
		icon.sprite = item.sprite;
		icon.enabled = true;

		Color zm = text.color;
		zm.a = 1f;

		text.color = zm;

		removeButton.interactable = true;
	}

	public void ClearSlot ()
	{
		item = null;
		icon.sprite = null;
		icon.enabled = false;

		Color zm = text.color;
		zm.a = 0.0f;

		text.color = zm;

		Debug.Log("clear slot called");

		removeButton.interactable = false;
	}

	public void OnRemoveButton ()
	{
		Inventory.instance.Remove(item);
	}

}
