using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_stats : MonoBehaviour
{
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
    public float XP;
    public bool hit;
    GameObject[] enemy;
    GameObject player;
    public HP_bar_script HP_bar;
    public float timeToHPRes,timeToReciveHP;
    private float currentTime,currentTime2;
   
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        HP = Stamina*2.5f;
        AP = Strength*4;
        MP = Intellect*4;
        currentAP=AP;
        currentMP=MP;
        HP_bar.setMaxHP(HP);
        currentHP = HP;
    }
    private void Update() {
        HP_bar.setHP(currentHP);
        if(currentHP<1){
            gameObject.SetActive(false);
            player.GetComponent<stats>().XP+=XP;
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
}
