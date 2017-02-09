using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour, IHasChanged {
	[SerializeField] Transform slots;
	[SerializeField] Text inventoryText;
    public Transform dumpZone;
	public GameObject iconPrefab;
    
    public List<Item> inventory;
    
    
    private Transform playerCamera;

	void Start () {
            playerCamera = GameObject.Find("player").transform.Find("Main Camera");

		HasChanged ();
	}
	
	#region IHasChanged implementation
	public void HasChanged ()
	{
      
        //check for moved items
		foreach (Transform slotTransform in slots){
			GameObject item = slotTransform.GetComponent<Slot>().item;
			if (item){

			}
		}
	}
    
    public void ClearDumps(){
         //check for items dropped into the dump zone
        foreach(Transform child in dumpZone){
            foreach(Transform worldObject in child){
                DropItem(worldObject.gameObject);
            }
            Destroy(child.gameObject);
        }
    }
	#endregion
    
    public void AddItem(GameObject addItem){
        addItem.SetActive(false);
        foreach (Transform slotTransform in slots){
            GameObject itemGO = slotTransform.GetComponent<Slot>().item;
			if (itemGO == null){
                Item addItemItem = addItem.GetComponent<Item>();
                GameObject newImage=  (GameObject)Instantiate(iconPrefab,slotTransform);
                newImage.GetComponent<Image>().sprite = addItemItem.icon;
                addItem.transform.parent = newImage.transform;
                inventory.Add(addItemItem);
                break;
			}
        }

    }
    
    public void DropItem(GameObject dropItem){
        
        dropItem.transform.parent = null;
        dropItem.transform.position = playerCamera.position + playerCamera.forward*2;
        dropItem.SetActive(true);
                       
        inventory.Remove(dropItem.GetComponent<Item>());
    }
}


namespace UnityEngine.EventSystems {
	public interface IHasChanged : IEventSystemHandler {
		void HasChanged();
	}
}