using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public void OnPointerEnter(PointerEventData eventData){

	}
		
	public void OnPointerExit(PointerEventData eventData){

	}

	public void OnDrop(PointerEventData eventData){
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if(d!=null){
			d.parent = this.transform;
			d.transform.position = d.parent.transform.position;
			GameObject go = GameObject.Find("Controller");
			Debug.Log(go.scene.name);
			IDrop script = go.GetComponent<IDrop> ();
			script.Chosen (d.name);
		}
	}
}
