using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    float intel;
    public float range;
    public float baseDMG;
    public float cost;
    public float oldPositionX,oldPositionY;

    GameObject player;
    public GameObject hitEffect;
    public GameObject stunnedArrow;

    public Camera cam;
    Vector2 mousePos;
    private void Start() {
         player= GameObject.FindGameObjectWithTag("Player");
         cam = player.GetComponent<Player_Attack>().cam;
    }
    private void Update() {
        if(this.transform.position.x>=oldPositionX+range||this.transform.position.x<=oldPositionX-range){
            GameObject effect = Instantiate(stunnedArrow, transform.position, Quaternion.identity);
            Destroy(effect,2f);
            Destroy(gameObject);
        }
        if(this.transform.position.y>oldPositionY+range||this.transform.position.y<=oldPositionY-range){
            GameObject effect = Instantiate(stunnedArrow, transform.position, Quaternion.identity);
            Destroy(effect,2f);
            Destroy(gameObject);
        }
         mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
         intel = player.GetComponent<stats>().Intellect;
    }
    float DMGCalculate(float x,float baseDMG){
        float finalDMG;
        float random = Random.Range(0f,1f);
        finalDMG= (baseDMG+x/10)*(1+random);
        Debug.Log(finalDMG+"DMG");
        return finalDMG;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        collision.collider.GetComponent<Enemy_stats>().hp_lost(DMGCalculate(intel,baseDMG));
        collision.collider.GetComponent<Enemy_stats>().hit = true;
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        effect.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(mousePos.y,mousePos.x)*Mathf.Rad2Deg);
        Destroy(effect,0.2f);
        Destroy(gameObject);
    }
}
