using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startBattle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad (gameObject);
        SceneManager.sceneLoaded += OnScaneLoaded;
        gameObject.SetActive(false);
    }

    private void OnScaneLoaded(Scene scene,LoadSceneMode mode){
        if(scene.name=="gameScene"){
            SceneManager.sceneLoaded-=OnScaneLoaded;
            Destroy(gameObject);
        }
        else{
            gameObject.SetActive(scene.name=="battle");
        }

    }

}
