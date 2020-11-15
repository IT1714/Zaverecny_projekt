using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyEncounterPrefab;
    private bool spawning = false;
    void Start()
    {
        DontDestroyOnLoad (gameObject);
        SceneManager.sceneLoaded += OnScaneLoaded;
        
    }

private void OnScaneLoaded(Scene scene,LoadSceneMode mode){
        if(scene.name=="battle"){
            if(spawning){
                Instantiate(enemyEncounterPrefab);
            }
            SceneManager.sceneLoaded-=OnScaneLoaded;
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag =="Player"){
            spawning=true;
            SceneManager.LoadScene("battle");   
        }
    }
}
