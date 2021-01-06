using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveFire : MonoBehaviour
{
    [SerializeField]
    private GameObject bonefireMenu;
    [SerializeField]
    private GameObject HUDMenu;
    public GameObject Player;
    GameObject	[] enemy;

    

    private bool iteractAllowed;
    public bool menuIsOn;
    private bool setActive =  true;
    // Start is called before the first frame update
    void Start()
    {
        menuIsOn =false;
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        bonefireMenu.gameObject.SetActive(false);
        Player.GetComponent<Player_Controls>().MeleeAttack=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(iteractAllowed && Input.GetKeyDown(KeyCode.E)){
            interact();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag.Equals("Player")){
            iteractAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag.Equals("Player")){
            iteractAllowed = false;
            bonefireMenu.gameObject.SetActive(false);
            HUDMenu.gameObject.SetActive(true);
            Player.GetComponent<Player_Controls>().attack=true;
        }
    }

    private void interact(){
        if(menuIsOn){

        }else{
            if(setActive){
            bonefireMenu.gameObject.SetActive(true);
            setActive = false;
            HUDMenu.gameObject.SetActive(false);
            Player.GetComponent<Player_Controls>().attack=false;
            Player.GetComponent<stats>().SavePlayer();
            Player.GetComponent<Player_Attack>().SetPlayerStats();
            for(int i =0; i<enemy.Length ; i++ ){
                    Debug.Log(enemy[i]);
                    enemy[i].SetActive(true);
                    enemy[i].GetComponent<Enemy_stats>().currentHP=enemy[i].GetComponent<Enemy_stats>().HP;
                    enemy[i].GetComponent<Enemy_stats>().currentAP =enemy[i].GetComponent<Enemy_stats>().AP;
                    enemy[i].GetComponent<Enemy_stats>().currentMP=enemy[i].GetComponent<Enemy_stats>().MP;
                    enemy[i].GetComponent<Transform>().position= enemy[i].GetComponent<Enemy_move_script>().oldPosition;  
                }
            
            
            }else{
                bonefireMenu.gameObject.SetActive(false);
                setActive = true;
                HUDMenu.gameObject.SetActive(true);
                Player.GetComponent<Player_Controls>().attack=true;
            }
        }
        
        
        
    }
}
