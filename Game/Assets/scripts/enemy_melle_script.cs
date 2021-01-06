using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_melle_script : MonoBehaviour
{
public float speed;
public float dmg;
  private Transform player;
  private GameObject targetPlayer;
  private Vector2 target;
  public GameObject hitEffect;

  void Start() {
    targetPlayer =GameObject.FindGameObjectWithTag("Player");
    player = GameObject.FindGameObjectWithTag("Player").transform;
    target = new Vector2(player.position.x,player.position.y);   
  }
  void Update() {
    transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    Destroy(gameObject,0.1f);
  }

  void OnTriggerEnter2D(Collider2D other) {
    GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
    effect.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(target.y,target.x)*Mathf.Rad2Deg);
    if(other.CompareTag("Player")){
        targetPlayer.GetComponent<stats>().hp_lost(dmg);
        Destroy(effect, 0.2f);
        Destroy(gameObject);
    }
  }
}
