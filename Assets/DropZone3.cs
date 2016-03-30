using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone3 : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public void OnPointerEnter(PointerEventData eventData){

	}

	public void OnPointerExit(PointerEventData eventData){

	}

	public void OnDrop(PointerEventData eventData){
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if(d!=null){
			d.parent = this.transform;
			d.transform.position = d.parent.transform.position;
			//conditions relative to each situation
			//gameObject.GetComponent<scenario1>().Chosen(d.name);
			GameObject go = GameObject.Find("Controller");
			scenario3 script = (scenario3) go.GetComponent(typeof(scenario3));
			script.Chosen(d.name);
		}
	}
}