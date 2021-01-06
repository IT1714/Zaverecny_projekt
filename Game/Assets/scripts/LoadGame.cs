using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadGame : MonoBehaviour
{
    public GameObject unit;
    public GameObject Name;
    
    public float freePoints;
    public string PlayerName;
    
    public void playGame(){
        freePoints = unit.GetComponent<CreateCharacter>().freePoints;
        PlayerName = Name.GetComponent<TextMeshProUGUI>().text;
        if(PlayerName.Length>1&&freePoints ==0){
            this.GetComponent<CreateCharacter>().SavePlayer();
            SceneManager.LoadScene(2);
        }
 }
}
