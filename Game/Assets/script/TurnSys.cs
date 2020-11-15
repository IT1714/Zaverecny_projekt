    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnSys : MonoBehaviour
{
    [SerializeField]
    private GameObject actionMenu, enemyUnitsMenu;
    private List<UnitStats> unitsStats;
    public GameObject enemyEncounter;
    void Start()
    {
        unitsStats = new List<UnitStats>();
        //pridani postavy do listu
        GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
        foreach(GameObject playerUnit in playerUnits){
            UnitStats currentUnitStats = playerUnit.GetComponent<UnitStats>();
            currentUnitStats.CalculateNextActTurn (0);
            unitsStats.Add(currentUnitStats);
        }
        //pridani nepritele do listu
        GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
        foreach(GameObject enemyUnit in enemyUnits){
            UnitStats currentUnitStats = enemyUnit.GetComponent<UnitStats>();
            currentUnitStats.CalculateNextActTurn(0);
            unitsStats.Add(currentUnitStats);
        }
        //razeni listu
        unitsStats.Sort();
        actionMenu.SetActive(false);
        enemyUnitsMenu.SetActive(false);

        NextTurn();

    }

    public void NextTurn(){
        UnitStats currentUnitStats = unitsStats[0];
        unitsStats.Remove(currentUnitStats);

        if(!currentUnitStats.IsDead()){
            GameObject[] remainingEnemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
            //jsou vsichni nepratele mrtvi
            if(remainingEnemyUnits.Length == 0){
                enemyEncounter.GetComponent<CollectReward>().GetReward();
                SceneManager.LoadScene("gameScene");
            }
            //kontrola jestli je hrac mrtvy
            GameObject[] remainingFreandliUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
            if(remainingFreandliUnits.Length==0){
                SceneManager.LoadScene("Menu");
            }
            GameObject currentUnit = currentUnitStats.gameObject;

            currentUnitStats.CalculateNextActTurn(currentUnitStats.nextActTurn);
            unitsStats.Add(currentUnitStats);
            unitsStats.Sort();

            if(currentUnit.tag=="PlayerUnit"){
                Debug.Log("Player should act");
                GameObject.Find("PlayerParty").GetComponent<selectUnit>().SelectCurrentUnit(currentUnit.gameObject);
            } else{
                Debug.Log("enemy should act");
                currentUnit.GetComponent<EnemyUnitAction>().Act();
            }
        }else{
            NextTurn();
        }
    }
    public void WaitThenNextTurn(){
        StartCoroutine(WaitThenNextTurnRoutine());
    }
    private  IEnumerator WaitThenNextTurnRoutine(){
        yield return new WaitForSeconds(1.0f);
        NextTurn();
    }
}
