using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTarget : MonoBehaviour
{
    public GameObject owner;
    [SerializeField]
    private string attackAnimation;
    [SerializeField]
    private bool magicAttack;
    [SerializeField]
    private float manaCost;
    [SerializeField]
    private float ActionCost;
    [SerializeField]
    private float minAttackMultiplier;
    [SerializeField]
    private float maxAttackMultiplier;
    [SerializeField]
    private float minDefMultiplier;
    [SerializeField]
    private float maxDefMultiplier;

    public void Hit(GameObject target){
        //nastaveni vlastníka
        UnitStats ownerStats= owner.GetComponent<UnitStats>();
        //nastaveni cíle
        UnitStats targetStats = target.GetComponent<UnitStats>();
        //funkce pro útok
        if (ownerStats.MP>=manaCost){
            float attackMultiplier = Random.Range(minAttackMultiplier, maxAttackMultiplier);
            float damage = magicAttack ? (attackMultiplier * ownerStats.magick) : (attackMultiplier*ownerStats.attack);
            float defMultiplier = Random.Range(minDefMultiplier,maxDefMultiplier);
            damage = Mathf.Max(0,damage-(defMultiplier*targetStats.defens));
            owner.GetComponent<Animator>().Play(attackAnimation);
            targetStats.ReceiveDamage(damage);
            ownerStats.MP-=manaCost;
            ownerStats.AP-=ActionCost;
        }
    }
}
