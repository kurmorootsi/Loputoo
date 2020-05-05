using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropDestination : MonoBehaviour, IDropHandler
{
	private int items = 0;

	[SerializeField]
	private Image teacher;

	[SerializeField]
	public LevelManagerObject LevelManagerObject;

	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.pointerDrag != null)
		{
			if (eventData.pointerDrag.GetComponent<DragAndDrop>().correctAnswer)
			{
				eventData.pointerDrag.GetComponent<DragAndDrop>().droppedOnDestination = true;
				eventData.pointerDrag.GetComponent<DragAndDrop>().draggable = false;

				Vector2 position = GetComponent<RectTransform>().anchoredPosition;

				position.x -= 30;
				position.y = 100 - (items * 40);
				teacher.fillAmount += .25f;
				items++;

				eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = position;

				if (items == 4)
				{
					finishLevel();
				}
			}
		}
	}

	public void finishLevel()
	{
		StartCoroutine(CompleteLevel());
	}

	IEnumerator CompleteLevel()
	{
		yield return new WaitForSeconds(3.0f);
		LevelManagerObject.finishLevel();
	}


}
