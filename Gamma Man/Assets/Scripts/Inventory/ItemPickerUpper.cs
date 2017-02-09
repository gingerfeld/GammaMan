using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemPickerUpper : MonoBehaviour {
    public Inventory inv;
    private Transform playerCamera;
    void Start (){
        playerCamera = transform.Find("Main Camera");
    }
    void Update(){
        RaycastHit hit;
        if(Input.GetButtonDown("Select") && Physics.Raycast(playerCamera.position, playerCamera.forward, out hit)){
            if(hit.transform.tag == "Item"){
                 Item curItem = hit.transform.GetComponent<Item>(); 
                 inv.AddItem(curItem.gameObject);
            }
        }
    }
    void OnDrawGizmos(){

    }
}