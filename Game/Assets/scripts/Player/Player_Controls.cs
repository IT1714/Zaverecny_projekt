using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    public float moveSpead;
    public int Playerclass;
    public GameObject unit;
    public Animator animator;
    public GameObject menuCanvas;
    public Rigidbody2D rbPlayer,rb;
    public Camera cam;
    private Vector2 moveDirection;
    public Vector2 shootDirec;
    Vector2 mousePos;
    public bool attack;
    public bool MeleeAttack=true;
    public bool RangeAttack=true;
    public bool SpecialAttack=true;
    public float nextMelee,nextRange,nextSpecial;
    public float nextMeleeCount,nextRangeCount,nextSpecialCount;
    // Update is called once per frame
    private void Start() {
        menuCanvas.gameObject.SetActive(false);
        menuCanvas.GetComponent<Game_menu>().isActive=true;
    }
    void Update()
    {
        moveSpead=unit.GetComponent<stats>().speed;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        ProcessInputs();
    }

     void FixedUpdate() {
        Move();
        shootDirec = mousePos - rb.position;
        float angle = Mathf.Atan2(shootDirec.y, shootDirec.x)* Mathf.Rad2Deg-90f;
        rb.rotation=angle;
    }

    void ProcessInputs(){
        float moveX= Input.GetAxisRaw("Horizontal");
        float moveY= Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);
        if(moveX ==0 &&moveY==0 ){
            animator.SetFloat("speed", 0);
        }else{
            animator.SetFloat("speed", moveSpead);
        }
        moveDirection = new Vector2(moveX,moveY).normalized;
        menu();
        ifAttack(attack);
    }

    public void ifAttack(bool attack){
        if(attack==true){
            if(MeleeAttack==true){
                if(Input.GetKeyDown(KeyCode.Mouse0)){
                    unit.GetComponent<Player_Attack>().mele();
                    Debug.Log(mousePos);
                    nextMelee=Time.time + nextMeleeCount;
                    MeleeAttack=false;
                }
            }if(Time.time>nextMelee){
                    MeleeAttack=true;
            }if(RangeAttack==true){
                if(Input.GetKeyDown(KeyCode.Mouse1)){
                    unit.GetComponent<Player_Attack>().SwitchStatementRange();
                    nextRange=Time.time + nextRangeCount;
                    RangeAttack=false;
                }
            }if(Time.time>nextRange){
                    RangeAttack=true;
            }
            if(SpecialAttack==true){
                if(Input.GetKeyDown(KeyCode.Q)){
                    unit.GetComponent<Player_Attack>().SwitchStatementSpecial();
                    nextSpecial=Time.time + nextSpecialCount;
                    SpecialAttack=false;
                }
            }if(Time.time>nextSpecial){
                SpecialAttack=true;
            }
            
        }
    }
    public void menu(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            menuCanvas.GetComponent<Game_menu>().Interact();
        }
    }

    void Move(){
        rbPlayer.velocity = new Vector2(moveDirection.x * moveSpead, moveDirection.y * moveSpead);
        rb.velocity = rbPlayer.velocity;

    }
}