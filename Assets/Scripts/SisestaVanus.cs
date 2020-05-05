using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SisestaVanus : MonoBehaviour, IDropHandler
{
	private int number;

	[SerializeField]
	public LevelManagerObject LevelManagerObject;

	[SerializeField]
	public Text text;

	private int tries;

	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.pointerDrag != null)
		{
			tries++;
			eventData.pointerDrag.GetComponent<DragNumbers>().droppedOnDestination = true;
			this.number = eventData.pointerDrag.GetComponent<DragNumbers>().number;
			text.text = ""+number;
			LevelManagerObject.tries++;
		}	
	}

}
