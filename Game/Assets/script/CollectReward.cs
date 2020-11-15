using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectReward : MonoBehaviour
{
    [SerializeField]
    private float experience;
    // Start is called before the first frame update
    void Start()
    {
        GameObject turnSystem = GameObject.Find("TurnSys");
        turnSystem.GetComponent<TurnSys>().enemyEncounter=gameObject;
    }

    public void GetReward(){
        GameObject[] livingPlayerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
        float experiencePerUnit = experience / livingPlayerUnits.Length;

        foreach(GameObject playerUnit in livingPlayerUnits){
            playerUnit.GetComponent<UnitStats>().ReceiveExperience (experiencePerUnit);
        }
        Destroy(gameObject);
    }
}
