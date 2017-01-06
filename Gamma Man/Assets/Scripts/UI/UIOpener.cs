using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIOpener : MonoBehaviour {
    public GameObject UICanvas;
    
    Transform invMenu;
    Transform gameMenu;
    
    void Start(){
        invMenu = UICanvas.transform.FindChild("invMenu");
        gameMenu = UICanvas.transform.FindChild("gameMenu");
    }
    
    void Update(){
        if(Input.GetButtonDown("Menu")){
                if(gameMenu.gameObject.activeSelf){
                Time.timeScale = 1.0f;
                gameMenu.gameObject.SetActive(false);
                print("Closing menu");
            }else{
                Time.timeScale = 0.0f;
                gameMenu.gameObject.SetActive(true);
                print("Opening menu");
            }
        }else if (Input.GetButtonDown("Inventory")){
            if(invMenu.gameObject.activeSelf){
                Time.timeScale = 1.0f;
                invMenu.gameObject.SetActive(false);
                print("Closing inventory");
            }else{
                Time.timeScale = 0.0f;
                invMenu.gameObject.SetActive(true);
                print("Opening inventory");
            }
        }
    }
}