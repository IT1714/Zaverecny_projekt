using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
 public void playGame(){
     string path = Application.persistentDataPath +"/saveSlot1.txt";
     if(File.Exists(path)){
        SceneManager.LoadScene(2);
        Debug.Log(path);
     }else{
         string pathPom = Application.persistentDataPath +"/saveSlot1pom.txt";
        if(File.Exists(pathPom)){
            SceneManager.LoadScene(2);
        }else{
             SceneManager.LoadScene(1);
        }
     }
 }
 public void settings(){
     SceneManager.LoadScene(4);
 }public void InGameSettings(){
     SceneManager.LoadScene(5);
 }
 public void Load(){
     SceneManager.LoadScene(3);
 }
 public void quitGame(){
     Application.Quit();
 }
 public void backToMenu(){
     SceneManager.LoadScene(0);
 }

}