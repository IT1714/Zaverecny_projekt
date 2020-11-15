using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
 public void playGame(){
     SceneManager.LoadScene(1);
 }
 public void settings(){
     SceneManager.LoadScene(2);
 }
 public void quitGame(){
     Application.Quit();
 }
 public void backToMenu(){
     SceneManager.LoadScene(0);
 }

}
