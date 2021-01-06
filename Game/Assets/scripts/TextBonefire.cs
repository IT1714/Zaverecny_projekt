using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBonefire : MonoBehaviour
{   
    public GameObject Agility;
    public GameObject Stamina;
    public GameObject Strength;
    public GameObject Intellect;
    public GameObject lvl;
    public GameObject currency;
    public GameObject RequaredCurenci;
    public GameObject Player;
    public GameObject Base_speed, Base_HP, Base_AP, Base_MP;
    public GameObject speedIfLvl,HPIfLvl,APIfLvl,MPIfLvl;
    private float AgilityCurent,StaminaCurent,StrengthCurent,IntelectCurent;
    private float requaredCurenci;
    private int lvlCurent,lvlint;

    // Start is called before the first frame update
    void Start()
    {
        AgilityCurent=Player.GetComponent<stats>().Agility;
        StaminaCurent=Player.GetComponent<stats>().Stamina;
        StrengthCurent=Player.GetComponent<stats>().Strength;
        IntelectCurent=Player.GetComponent<stats>().Intellect;
        lvlCurent = Player.GetComponent<stats>().lvl;
        lvlint=lvlCurent-1;
        requaredCurenci +=10* Mathf.Pow(1.5f,lvlint);
    }

    // Update is called once per frame
    void Update()
    {   Base_AP.GetComponent<TextMeshProUGUI>().text=Player.GetComponent<stats>().AP.ToString("F1");
        Base_MP.GetComponent<TextMeshProUGUI>().text=Player.GetComponent<stats>().MP.ToString("F1");
        Base_HP.GetComponent<TextMeshProUGUI>().text=Player.GetComponent<stats>().HP.ToString("F1");
        Base_speed.GetComponent<TextMeshProUGUI>().text=Player.GetComponent<stats>().speed.ToString("F1");
        Agility.GetComponent<TextMeshProUGUI>().text = AgilityCurent.ToString();
        Stamina.GetComponent<TextMeshProUGUI>().text = StaminaCurent.ToString();
        Strength.GetComponent<TextMeshProUGUI>().text = StrengthCurent.ToString();
        Intellect.GetComponent<TextMeshProUGUI>().text = IntelectCurent.ToString();
        RequaredCurenci.GetComponent<TextMeshProUGUI>().text = requaredCurenci.ToString("F1");
        lvl.GetComponent<TextMeshProUGUI>().text =lvlCurent.ToString();
        currency.GetComponent<TextMeshProUGUI>().text = Player.GetComponent<stats>().XP.ToString();
        if(Player.GetComponent<stats>().XP<requaredCurenci){
            RequaredCurenci.GetComponent<TextMeshProUGUI>().color=new Color32(255,0,0,255);
        }if(Player.GetComponent<stats>().XP>requaredCurenci){
            RequaredCurenci.GetComponent<TextMeshProUGUI>().color=new Color32(255,255,255,255);
        }if(Player.GetComponent<stats>().lvl==lvlCurent){
            APIfLvl.GetComponent<TextMeshProUGUI>().text=Player.GetComponent<stats>().AP.ToString("F1");
            MPIfLvl.GetComponent<TextMeshProUGUI>().text=Player.GetComponent<stats>().MP.ToString("F1");
            HPIfLvl.GetComponent<TextMeshProUGUI>().text=Player.GetComponent<stats>().HP.ToString("F1");
            speedIfLvl.GetComponent<TextMeshProUGUI>().text=Player.GetComponent<stats>().speed.ToString("F1");
        }if(Player.GetComponent<stats>().lvl<lvlCurent){
            APIfLvl.GetComponent<TextMeshProUGUI>().text=(StrengthCurent*1.3f).ToString("F1");
            MPIfLvl.GetComponent<TextMeshProUGUI>().text=(IntelectCurent*1.3f).ToString("F1");
            HPIfLvl.GetComponent<TextMeshProUGUI>().text=(StaminaCurent*2f).ToString("F1");
            speedIfLvl.GetComponent<TextMeshProUGUI>().text=(AgilityCurent*0.7f).ToString("F1");
        }
    }

    public void AgilityPlus(){
        if(Player.GetComponent<stats>().XP>=requaredCurenci){
            AgilityCurent++;
            lvlCurent ++;
            lvlint++;
            requaredCurenci +=10* Mathf.Pow(1.5f,lvlint);
        }
        
    }
    public void AgilityMinus(){
        if(AgilityCurent>Player.GetComponent<stats>().Agility){
            AgilityCurent--;
            lvlCurent --;
             requaredCurenci -=10* Mathf.Pow(1.5f,lvlint);
             lvlint--;
        }
        
    }
        public void StaminaPlus(){
        if(Player.GetComponent<stats>().XP>=requaredCurenci){
            StaminaCurent++;
            lvlCurent ++;
            lvlint++;
            requaredCurenci +=10* Mathf.Pow(1.5f,lvlint);
        }
        
    }
    public void StaminaMinus(){
        if(StaminaCurent>Player.GetComponent<stats>().Stamina){
            StaminaCurent--;
            lvlCurent --;
             requaredCurenci -=10* Mathf.Pow(1.5f,lvlint);
             lvlint--;
        }
        
    }
        public void StrengthPlus(){
        if(Player.GetComponent<stats>().XP>=requaredCurenci){
            StrengthCurent++;
            lvlCurent ++;
            lvlint++;
            requaredCurenci +=10* Mathf.Pow(1.5f,lvlint);
        }
        
    }
    public void StrengthMinus(){
        if(StrengthCurent>Player.GetComponent<stats>().Strength){
            StrengthCurent--;
            lvlCurent --;
             requaredCurenci -=10* Mathf.Pow(1.5f,lvlint);
             lvlint--;
        }
        
    }
        public void IntellectPlus(){
        if(Player.GetComponent<stats>().XP>=requaredCurenci){
            IntelectCurent++;
            lvlCurent ++;
            lvlint++;
            requaredCurenci +=10* Mathf.Pow(1.5f,lvlint);
        }
        
    }
    public void IntellectMinus(){
        if(IntelectCurent>Player.GetComponent<stats>().Intellect){
            IntelectCurent--;
            lvlCurent --;
             requaredCurenci -=10* Mathf.Pow(1.5f,lvlint);
             lvlint--;
        }
        
    }
    public void save(){
        if(Player.GetComponent<stats>().XP>=10* Mathf.Pow(1.5f,lvlint-1)){
            if(Player.GetComponent<stats>().lvl<lvlCurent){
                saveStats();
            }
            
        }
    }

    public void saveStats(){
        Player.GetComponent<stats>().XP-=10* Mathf.Pow(1.5f,lvlint-1);
        Player.GetComponent<stats>().Agility=AgilityCurent;
        Player.GetComponent<stats>().Stamina=StaminaCurent;
        Player.GetComponent<stats>().Strength=StrengthCurent;
        Player.GetComponent<stats>().Intellect=IntelectCurent;
        Player.GetComponent<stats>().lvl=lvlCurent;
        Player.GetComponent<stats>().SavePlayer();
        Player.GetComponent<Player_Attack>().SetPlayerStats();
    }
}
