using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Object : ScriptableObject
{
	new public string name = "New Item";
	public Sprite icon = null;
	public bool isDefault = false;
	public bool enabled = true;
}
