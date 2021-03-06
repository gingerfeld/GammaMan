﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public static GameObject itemBeingDragged;
    public Inventory inventory;
    public Transform dumpZone;
	Vector3 startPosition;
	Transform startParent;
    void Start(){
        inventory = transform.parent/*slot*/.parent/*inventoryPanel*/.parent/*inventory*/.GetComponent<Inventory>();
        dumpZone = inventory.transform.Find("DumpZone");
    }
	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		transform.position = eventData.position;
        transform.position -= Vector3.forward;
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		itemBeingDragged = null;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		if((transform.parent == startParent) && (Vector3.Distance(transform.position,startPosition)>1)){
			transform.SetParent(dumpZone);
            transform.gameObject.SetActive(false);
            inventory.ClearDumps(); 
		}else if(transform.parent == startParent){
            transform.position = startPosition;
        }
	}
	#endregion
}