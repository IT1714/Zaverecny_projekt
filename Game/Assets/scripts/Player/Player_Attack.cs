 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Player_Attack : MonoBehaviour
{
    public GameObject unit;
    public float HP,currentHP;
    public float MP,currentMP;
    public float AP,currentAP;
    public HP_bar_script HP_bar;
    public MP_bar_script MP_bar;
    public AP_bar_script AP_bar;
    public float Intellect;
    public float Agility;
    public float Strength;
    public float Stamina;
    public string saveSlot;
    public string PlayerClass;
    public int playerClassInt;
    public string Name;
    public GameObject fireballPrefab;
    public GameObject MeleePrefab;
    public GameObject arrowPrefab;
    public Transform center;
    public float fireballSpeed=20f;
    public int meleeSpeed=10;
    public float arrowSpeed=15f;
    public float manaCost;
    public Camera cam;
    float x,y;
    Vector2 mousePos;
    private float pom;
    public int lvl;
    public int character;
    public float xp;
    string path;
    public Vector3 position;
    Player_data_inGame dataInGame;
    public Animator animator;
    Player_data data;
    // Start is called before the first frame update
    void Start()
    {   
        path = Application.persistentDataPath +"/saveSlot1pom.txt";
        SetPlayerStats();
    }
    public void LoadPlayer(){
        unit.GetComponent<stats>().load_is_true = true;
        if(File.Exists(path)){
            Player_data_inGame dataInGame = SaveSys.LoadPlayerWithSaveInGame("saveSlot1");
            xp = dataInGame.xp;
            Intellect=dataInGame.Intellect;
            Agility=dataInGame.Agility;
            Strength=dataInGame.Strength;
            Stamina=dataInGame.Stamina;
            PlayerClass = dataInGame.classesString;
            Name = dataInGame.Name;
            saveSlot = dataInGame.saveSlot;
            lvl = dataInGame.lvl;
            character = dataInGame.character;
            position.x=dataInGame.position[0];
            position.y=dataInGame.position[1];
            position.z=dataInGame.position[2];

        }else{
            Player_data data = SaveSys.LoadPlayerWithSave("saveSlot1");
            character=data.character;
            Intellect=data.Intellect;
            Agility=data.Agility;
            Strength=data.Strength;
            Stamina=data.Stamina;
            PlayerClass = data.classesString;
            playerClassInt=data.classesInt;
            Name = data.Name;
            saveSlot = data.saveSlot;
            lvl = data.lvl;
        }
        Debug.Log(Application.persistentDataPath);

    }
    public void SetPlayerStats(){
        LoadPlayer();
        unit.GetComponent<stats>().character=character;
        animator.SetInteger("characterNum",character);
        unit.GetComponent<stats>().HP = Stamina*2f;
        unit.GetComponent<stats>().AP = Strength*1.3f;
        unit.GetComponent<stats>().MP = Intellect*1.3f;
        unit.GetComponent<stats>().speed=(unit.GetComponent<stats>().Agility)*0.7f;
        HP = unit.GetComponent<stats>().HP;
        AP = unit.GetComponent<stats>().AP;
        MP = unit.GetComponent<stats>().MP;
        HP_bar.setMaxHP(HP);
        AP_bar.setMaxAP(AP);
        MP_bar.setMaxMP(MP);
        unit.GetComponent<stats>().lvl = lvl;
        unit.GetComponent<stats>().XP = xp;
        unit.GetComponent<stats>().Intellect = Intellect;
        unit.GetComponent<stats>().Agility = Agility;
        unit.GetComponent<stats>().Strength = Strength;
        unit.GetComponent<stats>().Stamina = Stamina;
        unit.GetComponent<stats>().Stamina = Stamina;
        unit.GetComponent<stats>().Name = Name;
        unit.GetComponent<stats>().saveSlot = saveSlot;
        unit.GetComponent<stats>().Class = PlayerClass;
        unit.GetComponent<Transform>().position= position;
        Debug.Log(position);
    }
    
    public void SwitchStatementRange(){
        switch(playerClassInt){
            //warlock
            case 0:
            Debug.Log(PlayerClass);
                    if(unit.GetComponent<stats>().ifCost(fireballPrefab.GetComponent<fireball>().cost, unit.GetComponent<stats>().currentMP)==true){
                    shootFireball();
                    unit.GetComponent<stats>().mp_lost(fireballPrefab.GetComponent<fireball>().cost);
                }
                break;
            //warior
            case 1:
            Debug.Log(PlayerClass);
                if(unit.GetComponent<stats>().ifCost(arrowPrefab.GetComponent<Arrow>().cost, unit.GetComponent<stats>().currentAP)==true){
                    arrowShoot();
                    unit.GetComponent<stats>().ap_lost(arrowPrefab.GetComponent<Arrow>().cost);
                }
                break;
            //hunter
            case 2:
            Debug.Log(PlayerClass);
                if(unit.GetComponent<stats>().ifCost(arrowPrefab.GetComponent<fireball>().cost, unit.GetComponent<stats>().currentMP)==true){
                    arrowShoot();
                    unit.GetComponent<stats>().ap_lost(arrowPrefab.GetComponent<Arrow>().cost);
                }
                break;
        }
    }

        public void SwitchStatementSpecial(){
        switch(playerClassInt){
            //warlock
            case 0:
            Debug.Log(PlayerClass);
                shootFireball();
                break;
            //warior
            case 1:
            Debug.Log(PlayerClass);
                mele();
                break;
            //hunter
            case 2:
            Debug.Log(PlayerClass);
                mele();
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {   
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        currentHP = unit.GetComponent<stats>().currentHP;
        currentAP = unit.GetComponent<stats>().currentAP;
        currentMP = unit.GetComponent<stats>().currentMP;
        HP_bar.setHP(currentHP);
        MP_bar.setMP(currentMP);
        AP_bar.setAP(currentAP);
    }
    void shootFireball(){
        GameObject fireball= Instantiate(fireballPrefab,center.position, center.rotation);
        fireball.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(mousePos.y,mousePos.x)* Mathf.Rad2Deg);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        fireball.GetComponent<fireball>().oldPositionX = unit.transform.position.x;
        fireball.GetComponent<fireball>().oldPositionY = unit.transform.position.y;
        rb.AddForce(center.up * fireballSpeed, ForceMode2D.Impulse);
    }   
    public void mele(){
        GameObject melee=Instantiate(MeleePrefab,center.position,center.rotation);
        melee.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(mousePos.y,mousePos.x)-180);
        Rigidbody2D rb = melee.GetComponent<Rigidbody2D>();
        melee.GetComponent<melee>().oldPositionX = unit.transform.position.x;
        melee.GetComponent<melee>().oldPositionY = unit.transform.position.y;
        rb.AddForce(center.up * 10, ForceMode2D.Impulse);
    }

    void arrowShoot(){
        GameObject arrow= Instantiate(arrowPrefab,center.position, center.rotation);
        arrow.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(mousePos.y,mousePos.x)-90);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        arrow.GetComponent<Arrow>().oldPositionX = unit.transform.position.x;
        arrow.GetComponent<Arrow>().oldPositionY = unit.transform.position.y;
        rb.AddForce(center.up * 15, ForceMode2D.Impulse);
    }
}
