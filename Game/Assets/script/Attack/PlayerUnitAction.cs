using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUnitAction : MonoBehaviour
{
    [SerializeField]
    private GameObject physicalAttackPrefab;
    [SerializeField]
    private GameObject magicalAttackPrefab;
    [SerializeField]
    private Sprite faceSprite;
    private GameObject currentAttack;
    private GameObject physicalAttack;
    private GameObject magicalAttack;

    
    void Awake() {
        physicalAttack = Instantiate(physicalAttackPrefab, transform);
        magicalAttack = Instantiate(magicalAttackPrefab, transform);

        physicalAttack.GetComponent<AttackTarget> ().owner=gameObject;
        magicalAttack.GetComponent<AttackTarget> ().owner=gameObject;
        currentAttack = physicalAttack;
    }
    public void Act(GameObject target){
        currentAttack.GetComponent<AttackTarget>().Hit(target);
    }
    public void SelectAttack(bool physicla){
        currentAttack=physicla ? physicalAttack :magicalAttack;
    }
    public void UpdateHUD(){
        GameObject playerUnitFace = GameObject.Find("PlayerUnityFace");
        playerUnitFace.GetComponent<Image>().sprite = faceSprite;
        GameObject playerUnityHealthBar = GameObject.Find("PlayerUnityHealthBar");
        playerUnityHealthBar.GetComponent<ShowUnitHealth>().CangeUnit(gameObject);
        GameObject playerUnityManaBar = GameObject.Find("PlayerUnityManaBar");
        playerUnityManaBar.GetComponent<ShowUnitMana>().CangeUnit(gameObject);

    }
}
