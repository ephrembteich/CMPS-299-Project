using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	private float diffX;
	private float diffY;
	public Transform parent = null;

	public void OnBeginDrag(PointerEventData eventData){
		if(this.transform.parent.name!="Canvas"){
			parent = this.transform.parent;
			this.transform.SetParent (this.transform.parent.parent);
		}
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData){
		this.transform.position = new Vector3(eventData.position.x+diffX, eventData.position.y+diffY, 0);
	}

	public void OnEndDrag(PointerEventData eventData){
		this.transform.SetParent (parent);
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	private float dist(float x1, float y1, float x2, float y2){
		diffX = x2 - x1;
		diffY = y2 - y1;
		return (float)Math.Sqrt (Math.Pow (diffX, 2) + Math.Pow (diffY, 2)) / 2;
	}
}