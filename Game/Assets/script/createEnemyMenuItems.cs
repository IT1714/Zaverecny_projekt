using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class createEnemyMenuItems : MonoBehaviour
{
    [SerializeField]
    private GameObject targetEnemyUnitPrefab;
    
    [SerializeField]
    private Sprite menuItemSprite;

    [SerializeField]
    private KillEnemy killEnemyScript;
    
        void Awake(){
            //Najde menu pro nepřátelskou jednotku
            GameObject enemyUnitsMenu = GameObject.Find("EnemyUnitsMenu"); 
            GameObject [] existingItems = GameObject.FindGameObjectsWithTag("TargetEnemyUnit");
            
            GameObject targetEnemyUnit =Instantiate(targetEnemyUnitPrefab, enemyUnitsMenu.transform);
            targetEnemyUnit.name = "Target" + gameObject.name;
            targetEnemyUnit.transform.localScale= new Vector2(0.8f,0.8f);
            targetEnemyUnit.GetComponent<Button>().onClick.AddListener(()=> SelectEnemyTarget());
            targetEnemyUnit.GetComponent<Image>().sprite = menuItemSprite;
            
            

            //přidání do kill scriptu
            killEnemyScript.menuItem= targetEnemyUnit;
    }

    public void SelectEnemyTarget(){
        GameObject partyData = GameObject.Find("PlayerParty");
        partyData.GetComponent<selectUnit>().AttackEnemyTarget(gameObject);
    }

}
