using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour
{
    public int lvl;
    public string Name;
    public string Class;
    public string saveSlot;
    public float HP;
    public float currentHP;
    public float currentMP;
    public float currentAP;
    public float AP;
    public float MP;
    public float Agility;
    public float Stamina;
    public float Strength;
    public float Intellect;
    public float speed;
    public float XP;
    float temporaryXP;
    public bool hit;
    GameObject[] enemy;
    GameObject player;
    public float timeToHPRes,timeToReciveHP;
    private float currentTime,currentTime2;
    public bool load_is_true;
    public int character;
    
    private void Start() {
        load_is_true=true;
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update() {
        if(currentHP<1&&load_is_true!=true){
                for(int i =0; i<enemy.Length ; i++ ){
                    Debug.Log(enemy[i]);
                    enemy[i].SetActive(true);
                    enemy[i].GetComponent<Enemy_stats>().currentHP=enemy[i].GetComponent<Enemy_stats>().HP;
                    enemy[i].GetComponent<Enemy_stats>().currentAP =enemy[i].GetComponent<Enemy_stats>().AP;
                    enemy[i].GetComponent<Enemy_stats>().currentMP=enemy[i].GetComponent<Enemy_stats>().MP;
                    enemy[i].GetComponent<Transform>().position= enemy[i].GetComponent<Enemy_move_script>().oldPosition;
                    load_is_true = true;    
                }
        }
        if(load_is_true==true){
            currentHP=HP;
            currentMP=MP;
            currentAP=AP;
            player.GetComponent<Player_Attack>().SetPlayerStats();
            load_is_true=false;
        }
        if(hit==false && currentHP<HP && currentHP>0){
            if(Time.time>currentTime2+timeToReciveHP){
                currentHP+=HP/80;
                currentTime2=Time.time;
                if(currentHP>HP){
                    currentHP=HP;
                }
            }
            
        }
        else{
            if(Time.time>currentTime+timeToHPRes){
                hit=false;
                currentTime2=Time.time;
            }
        }
    }
    public bool ifCost(float cost,float current){
        if(current>=cost){
            return true;
        }else{
            return false;
        }
    }
    public void mp_lost(float cost){
        currentMP -= cost;
    }
    public void ap_lost(float cost){
        currentAP -= cost;
        Debug.Log(currentAP);
    }
    public void hp_lost(float cost){
        currentHP -= cost;
        hit=true;
        currentTime=Time.time;
    }
        public void SavePlayer(){
            SaveSys.SavePlayerInGame(this,"saveSlot1");
    }
}
