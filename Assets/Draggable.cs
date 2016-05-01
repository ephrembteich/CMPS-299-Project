using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets
{
	public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		private float _diffX;
		private float _diffY;
		public Transform Parent;

		public void OnBeginDrag(PointerEventData eventData)
		{
			if (transform.parent.name != "Canvas")
			{
				Parent = transform.parent;
				transform.SetParent(transform.parent.parent);
			}
			GetComponent<CanvasGroup>().blocksRaycasts = false;
		}

		public void OnDrag(PointerEventData eventData)
		{
			transform.position = new Vector3(eventData.position.x + _diffX, eventData.position.y + _diffY, 0);
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			transform.SetParent(Parent);
			GetComponent<CanvasGroup>().blocksRaycasts = true;
		}

		private float Dist(float x1, float y1, float x2, float y2)
		{
			_diffX = x2 - x1;
			_diffY = y2 - y1;
			return (float) Math.Sqrt(Math.Pow(_diffX, 2) + Math.Pow(_diffY, 2))/2;
		}
	}
}