using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectUnit : MonoBehaviour
{
  private GameObject currentUnit;
  private GameObject actionsMenu;
  private GameObject enemyUnitsMenu;

  void Awake() {
      SceneManager.sceneLoaded += OnSceneLoaded;
  }
  private void OnSceneLoaded(Scene scane, LoadSceneMode mode){
      if(scane.name=="battle"){
          actionsMenu = GameObject.Find("ActionMenu");
          enemyUnitsMenu = GameObject.Find("EnemyUnitsMenu");
      }
  }
  public void SelectCurrentUnit(GameObject unit){
      currentUnit = unit;
      actionsMenu.SetActive(true);
      currentUnit.GetComponent<PlayerUnitAction>().UpdateHUD ();
  }
  public void SelectAttack(bool physical){
      currentUnit.GetComponent<PlayerUnitAction>().SelectAttack(physical);
      actionsMenu.SetActive(false);
      enemyUnitsMenu.SetActive(true);
  }
  public void AttackEnemyTarget(GameObject target){
      actionsMenu.SetActive(false);
      enemyUnitsMenu.SetActive(false);

      currentUnit.GetComponent<PlayerUnitAction>().Act(target);
  }
}
