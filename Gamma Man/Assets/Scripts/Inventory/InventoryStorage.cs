using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryStorage : MonoBehaviour {
    public List<item> inv = new List<item>();
   public float gridSize;
   
   
   public void AddItemToInventory(item i, coord grabOffset, coord dropPos){
        if(FitsInInventory(i, grabOffset,dropPos)){
            
        }
   }
    
    public bool FitsInInventory(item potentialFit, coord grabOffset, coord dropPos){
        foreach(coord potentialFitCoord in potentialFit.coordinates){
            coord invCoord = potentialFitCoord  + dropPos;
        }
        
        
        foreach(item otherItem in inv){
            foreach(coord otherCoord in otherItem.coordinates){
                coord otherCoord 
                foreach(coord potentialFitCoord in potentialFit.coordinates){
                    if(otherCoord.Equals(c)){
                        return false;
                    }
                }                        
            }
        }
        return true;
    }
   
}

[System.Serializable]
public class item{
    public string name;
    public string description;
    
    public GameObject worldObject;
    public Texture2D icon;
    
    public coord[] coordinates;
    public coord invPosition;
}

public class coord{
    public int x;
    public int y;
    public coord(int _x, int _y){
        x = _x;
        y = _y;
    }
    public static coord operator +(coord x, coord y){
        return new coord(x.x+y.x,x.y+y.y);
    }
    public static coord operator -(coord x, coord y){
        return new coord(x.x-y.x,x.y-y.y);
    }
    
    
    
}