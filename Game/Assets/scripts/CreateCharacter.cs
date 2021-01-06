using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCharacter : MonoBehaviour
{
    public string [] PlayerClasses ={"Warlock","Hunter","Warrior"};
    public string PlayerClass;
    public string saveSlot;
    public string Name;
    public int lvl;
    public Animator animator;
    public int max,curent,characterIMG,Maxanimation;
    public float Intellect;
    public float Agility;
    public float Strength;
    public float Stamina;
    public float BaseIntellect;
    public float BaseAgility;
    public float BaseStrength;
    public float BaseStamina;
    public int freePoints =5;

    private void Start() {
        SwitchStatement();
        foreach (string s in PlayerClasses)
        {
            max++;
        }
        Player_data data = SaveSys.LoadPlayerWithSave(saveSlot);
        if(data==null){
            saveSlot="saveSlot1";
        }
        lvl =1;
    }
    private void Update() {
        animator.SetInteger("characterNum",characterIMG);
    }

    public void classesPlus(){
        if(curent >= max-1){
            curent =0;
        }else{
            curent++;
        }
        SwitchStatement();
        freePoints =5;
    }
    public void classesMinus(){
        if(curent <= 0){
            curent =max-1;
        }else{
            curent--;
        }
        SwitchStatement();
        freePoints =5;
    }
    void SwitchStatement(){
        switch (curent)
        {
            case 0:
                PlayerClass = PlayerClasses[0];
                Intellect=8;
                Agility=4;
                Strength=2;
                Stamina=6;
                BaseIntellect=Intellect;
                BaseAgility=Agility;
                BaseStrength=Strength;
                BaseStamina=Stamina;
                break;
            case 1:
                PlayerClass = PlayerClasses[1];
                Intellect=4;
                Agility=7;
                Strength=4;
                Stamina=5;
                BaseIntellect=Intellect;
                BaseAgility=Agility;
                BaseStrength=Strength;
                BaseStamina=Stamina;
                break;
            case 2:
                PlayerClass = PlayerClasses[2];
                Intellect=3;
                Agility=4;
                Strength=7;
                Stamina=6;

                BaseIntellect=Intellect;
                BaseAgility=Agility;
                BaseStrength=Strength;
                BaseStamina=Stamina;
                break;
            default:
                PlayerClass = PlayerClasses[0];
                break;
        }
    }

    public void IntellectPlus(){
        if(freePoints!=0){
            Intellect++;
            freePoints--;
        }
        
    }
    public void IntellectMinus(){
        if(Intellect!=0 && freePoints!=10 && Intellect>BaseIntellect){
            Intellect--;
            freePoints++;
        }
        
    }
    public void AgilityPlus(){
        if(freePoints!=0){
            Agility++;
            freePoints--;
        }
    }
    public void AgilityMinus(){
         if(Agility!=0 && freePoints!=10 &&Agility>BaseAgility){
            Agility--;
            freePoints++;
        }
    }
    public void StrengthPlus(){
        if(freePoints!=0){
            Strength++;
            freePoints--;
        }
    }
    public void StrengthMinus(){
         if(Strength!=0 && freePoints!=10 && Strength>BaseStrength){
            Strength--;
            freePoints++;
        }
    }
    public void StaminatPlus(){
        if(freePoints!=0){
            Stamina++;
            freePoints--;
        }
    }
    public void StaminatMinus(){
         if(Stamina!=0 && freePoints!=10 &&Stamina>BaseStamina){
            Stamina--;
            freePoints++;
        }
    }
    public void IMGPlus(){
        if(characterIMG >= Maxanimation-1){
            characterIMG =0;
        }else{
            characterIMG++;
        }
    }
    public void IMGMinus(){
        if(characterIMG <= 0){
            characterIMG =Maxanimation-1;
        }else{
            characterIMG--;
        }
    }

    public void SavePlayer(){
        SaveSys.SavePlayer(this, "saveSlot1");
    }
}
