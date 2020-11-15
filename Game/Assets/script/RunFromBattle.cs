﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunFromBattle : MonoBehaviour
{
    [SerializeField]
    private float runningChance= 0.5f;
    public void TryRunning(){
        float randomNumber = Random.value;
        if(randomNumber<runningChance){
            SceneManager.LoadScene("gameScene");
        }else{
            GameObject.Find("TurnSys").GetComponent<TurnSys>().NextTurn();
        }
    }
}
