    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class UnitStats : MonoBehaviour, IComparable{
[SerializeField]
private Animator animator;
[SerializeField]
private GameObject damageTextPrefab;
[SerializeField]
private Vector2 damageTextPosition;
 public float HP;
 public float MP;
 public float AP;
 public float magick;
 public float attack;
 public float defens;
 public float agility;
 public float XP;
 public int nextActTurn;
 private bool dead;
 public void CalculateNextActTurn(int currentTurn){
     nextActTurn = currentTurn + Mathf.CeilToInt(100f/agility);
 }
 public bool IsDead(){
     return dead;
 } 
 public int CompareTo(object otherStats){
     return nextActTurn.CompareTo(((UnitStats)otherStats).nextActTurn);
 }
 public void ReceiveDamage(float damage){
     HP -= damage;
     animator.Play("Hit");
     GameObject HUDCanvas = GameObject.Find("HUDcanvas");
     GameObject damageText = Instantiate(damageTextPrefab,HUDCanvas.transform);
     damageText.GetComponent<Text>().text="" +Mathf.FloorToInt(damage);
     damageText.transform.localPosition=damageTextPosition;
     damageText.transform.localScale=Vector2.one;
     Destroy(damageText.gameObject, 1f); 
     if(HP<=0){
         dead = true;
         gameObject.tag ="DeadUnit";
         Destroy(gameObject);
     }
     GameObject.Find("TurnSys").GetComponent<TurnSys>().WaitThenNextTurn();
 }
 public void ReceiveExperience(float newXP){
     XP += newXP;
 }
}
