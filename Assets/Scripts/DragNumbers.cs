using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNumbers : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
	[SerializeField]
	private Canvas canvas;

	private RectTransform rectTransform;
	private Vector2 startPosition;

	private CanvasGroup canvasGroup;

	public bool droppedOnDestination = false;

	[SerializeField]
	public int number;

	private void Start()
	{
		startPosition = rectTransform.position;
	}

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		canvasGroup = GetComponent<CanvasGroup>();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		droppedOnDestination = false;
		Debug.Log("begin drag");
		canvasGroup.alpha = .8f;
		canvasGroup.blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		StartCoroutine(Wait());

		if (droppedOnDestination == false)
		{
			Debug.Log("false");
			rectTransform.position = startPosition;
		} else
		{
			Debug.Log("destroy");
			Destroy(this.gameObject);
		}

		Debug.Log("end drag");
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

	IEnumerator Wait()
	{
		yield return new WaitForEndOfFrame();
	}
}
