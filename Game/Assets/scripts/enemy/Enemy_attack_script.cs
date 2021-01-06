using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_attack_script : MonoBehaviour
{
    public GameObject unit;
    public GameObject target;
    public GameObject MeleePrefab;
    public GameObject RangePrefab;
    public float rangeCost;
    public float meleeCost;
    private float time;
    private float nextFireTime;
    private float x,p,z;
    private bool wait;
    public Vector2 targetPos;
    public Vector2 shootDirec;
    private float timeBtwShots;
    public float startTimeBtwShots;


    void Start() {
        timeBtwShots = startTimeBtwShots;
        target = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update() {
        targetPos = target.transform.position;
    }
    public void mele(){
        if(timeBtwShots<=0){
            Instantiate(MeleePrefab, unit.transform.position,Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
            unit.GetComponent<Enemy_stats>().ap_lost(meleeCost);
        }else{
            timeBtwShots -= Time.deltaTime;
        }
    }public void range(){
        if(timeBtwShots<=0){
            Instantiate(RangePrefab, unit.transform.position,Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
            unit.GetComponent<Enemy_stats>().mp_lost(rangeCost);
        }else{
            timeBtwShots -= Time.deltaTime;
        }
       
    }
}