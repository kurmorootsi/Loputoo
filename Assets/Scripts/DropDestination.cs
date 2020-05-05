using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropDestination : MonoBehaviour, IDropHandler
{
	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log("drop");
		
		if (eventData.pointerDrag != null)
		{
			eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
		}
	}


}
