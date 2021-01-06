using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_menu : MonoBehaviour
{
    public bool isActive;
    public GameObject FireMenu,Player,HUD;
    // Update is called once per frame
    public void Interact(){
        if(isActive==true){
            this.gameObject.SetActive(true);
            FireMenu.gameObject.SetActive(false);
            Player.GetComponent<Player_Controls>().attack=false;
            HUD.gameObject.SetActive(true);
            isActive=false;
        }else{
            this.gameObject.SetActive(false);
            Player.GetComponent<Player_Controls>().attack=true;
            isActive=true;
        }
         
         
    }
}
