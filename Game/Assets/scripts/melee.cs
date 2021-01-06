using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour
{
    public float oldPositionX,oldPositionY;
    float strength;
    public float range;
    public float baseDMG;

    public Camera cam;
    GameObject player;
    Vector2 mousePos;

    public GameObject hitEffect;
    private void Start() {
         player= GameObject.FindGameObjectWithTag("Player");
         cam = player.GetComponent<Player_Attack>().cam;
    }
    private void Update() {
        if(this.transform.position.x>=oldPositionX+range||this.transform.position.x<=oldPositionX-range){
            Destroy(gameObject,0.1f);
        }
        if(this.transform.position.y>oldPositionY+range||this.transform.position.y<=oldPositionY-range){
            Destroy(gameObject,0.1f);
        }
         mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
         strength = player.GetComponent<stats>().Strength;
 }
 float DMGCalculate(float x,float baseDMG){
        float finalDMG;
        float random = Random.Range(0f,1f);
        finalDMG= (baseDMG+x/4)*(1+random);
        Debug.Log(finalDMG+"DMG");
        return finalDMG;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        collision.collider.GetComponent<Enemy_stats>().hp_lost(DMGCalculate(strength,baseDMG));
        collision.collider.GetComponent<Enemy_stats>().hit = true;
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        effect.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(mousePos.y,mousePos.x)*Mathf.Rad2Deg);
        Destroy(effect,0.2f);
        Destroy(gameObject);
    }
 
}
