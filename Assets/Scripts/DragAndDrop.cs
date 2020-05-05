using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
	[SerializeField]
	private Canvas canvas;

	private RectTransform rectTransform;
	private Vector2 startPosition;

	private CanvasGroup canvasGroup;

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		canvasGroup = GetComponent<CanvasGroup>();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		Debug.Log("begin drag");
		startPosition = rectTransform.position;
		canvasGroup.alpha = .8f;
		canvasGroup.blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		Debug.Log("end drag");
		rectTransform.position = startPosition;
		canvasGroup.blocksRaycasts = true;
		canvasGroup.alpha = 1f;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		Debug.Log("pointer down");
	}

	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log("drop");
	}
}
