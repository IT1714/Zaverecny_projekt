using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadMenu : MonoBehaviour
{
    public GameObject Nametext;
    public GameObject ClasAndlvl;
    public GameObject LoadMenu1;
    public GameObject createMenu1;
    private int lvl;
    void Start()
    {
        LoadPlayer();
    }
    public void LoadPlayer(){
        Player_data data1 = SaveSys.LoadPlayerWithSave("saveSlot1");
        lvl = data1.lvl+1;
        if(data1 == null){
            LoadMenu1.SetActive(false);
        }
        if(data1 != null){
            createMenu1.SetActive(false);
            Nametext.GetComponent<TextMeshProUGUI>().text = data1.Name;
            ClasAndlvl.GetComponent<TextMeshProUGUI>().text = data1.classesString +" LVL. "+lvl;
        }        
    }
    void Update()
    {
        
    }
}
