using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropDestination : MonoBehaviour, IDropHandler
{
	private int items = 0;

	[SerializeField]
	private GameObject tyhi_koht;

	[SerializeField]
	private GameObject klass_koht;

	[SerializeField]
	private Image dropped_class_image;

	[SerializeField]
	private GameObject dropped_class;

	[SerializeField]
	public LevelManagerObject LevelManagerObject;

	public bool is_tyhi = true;

	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.pointerDrag != null)
		{
			if (eventData.pointerDrag.GetComponent<DragAndDrop>().correctAnswer && is_tyhi)
			{
				is_tyhi = false;
				eventData.pointerDrag.GetComponent<DragAndDrop>().droppedOnDestination = true;
				eventData.pointerDrag.GetComponent<DragAndDrop>().draggable = false;

				dropped_class = eventData.pointerDrag.GetComponent<DragAndDrop>().gameObject;
				dropped_class_image.gameObject.SetActive(true);
				dropped_class_image.sprite = eventData.pointerDrag.GetComponent<DragAndDrop>().sprite;

				tyhi_koht.SetActive(false);
				klass_koht.SetActive(true);
				dropped_class.SetActive(false);
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

	private void Start()
	{
		
	}

}
