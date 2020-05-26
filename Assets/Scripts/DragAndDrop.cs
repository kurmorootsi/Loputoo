using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
	[SerializeField]
	private Canvas canvas;

	private RectTransform rectTransform;
	private Vector2 startPosition;

	private CanvasGroup canvasGroup;

	public bool droppedOnDestination = false;

	public bool draggable = true;

	public bool ulemActive = false;

	[SerializeField]
	public bool isPara;

	[SerializeField]
	public bool correctAnswer;

	[SerializeField]
	public bool isObject;

	[SerializeField]
	public bool canUlem;

	[SerializeField]
	public string classType = "";

	[SerializeField]
	public Sprite sprite;

	[SerializeField]
	public Transform itemsParent;

	Inventory inventory;

	InventorySlot[] slots;

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
		if (draggable)
		{
			canvasGroup.alpha = .8f;
			canvasGroup.blocksRaycasts = false;
		}

	}

	public void OnDrag(PointerEventData eventData)
	{
		if (draggable)
		{
			rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (draggable)
		{
			StartCoroutine(Wait());

			if (droppedOnDestination == false)
			{
				rectTransform.position = startPosition;
			}

			canvasGroup.blocksRaycasts = true;
			canvasGroup.alpha = 1f;
		}

	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnDrop(PointerEventData eventData)
	{
	}

	IEnumerator Wait()
	{
		yield return new WaitForEndOfFrame();
	}
}
