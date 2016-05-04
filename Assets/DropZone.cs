using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets
{
	public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
	{
		public void OnDrop(PointerEventData eventData)
		{
			var d = eventData.pointerDrag.GetComponent<Draggable>();
			if (d != null && transform.childCount == 0)
			{
				d.Parent = transform;
				d.transform.position = d.Parent.transform.position;
				var go = GameObject.Find("Controller");
				var script = go.GetComponent<IDrop>();
				script.Chosen(d.name);
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}
	}
}