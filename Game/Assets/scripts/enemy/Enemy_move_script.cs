using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_move_script : MonoBehaviour
{   
    public GameObject unit;
    public bool mele;
    public int range,sight,z;
    public float MeleeDistance,RangeDistance;
    private float MP,x,y,speed,p,waitf,waitTime;
    private bool followPlayer, randomMove, arrived,wait;
    private Transform target;
    public Vector2 oldPosition;
    Vector2 newPosition,randomPosition;
    // Start is called before the first frame update
    void Start()
    {
        speed=unit.GetComponent<Enemy_stats>().Agility*0.7f;
        target =  GameObject.FindGameObjectWithTag("Player").transform;
        x= unit.transform.position.x;
        y= unit.transform.position.y;
        oldPosition = new Vector2(x,y);
        followPlayer=false;
        arrived = true;
        waitf=0.1f;
        z=0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position)<sight){
            followPlayer = true;
            if(mele == true){
                if(Vector2.Distance(transform.position, target.position)<MeleeDistance){
                    if(unit.GetComponent<Enemy_stats>().ifCost(unit.GetComponent<Enemy_attack_script>().meleeCost,unit.GetComponent<Enemy_stats>().currentMP)==true){
                        unit.GetComponent<Enemy_attack_script>().mele();
                        Debug.Log(unit);
                    }
                    
                }else{
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                }
            }else{
                if(Vector2.Distance(transform.position, target.position)<RangeDistance){
                    if(unit.GetComponent<Enemy_stats>().ifCost(unit.GetComponent<Enemy_attack_script>().rangeCost,unit.GetComponent<Enemy_stats>().currentMP)==true){
                        unit.GetComponent<Enemy_attack_script>().range();
                    }    
                }else{
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                }
            }
        }else{
            if(followPlayer==true){
                transform.position = Vector2.MoveTowards(transform.position, oldPosition, speed * Time.deltaTime);
                arrived = true;
            }if(Vector2.Distance(transform.position, oldPosition)==0 && arrived == true){
                followPlayer=false;
                randomMove = true;
                arrived = false; 
            }if(followPlayer == false && randomMove == true){
                //casovac
                if(Time.time > waitTime){
                    waitTime= Time.time + waitf;
                    p= Time.time;
                    wait=true;
                    switch (z){
                        case 0:
                            
                            break;
                        case 1:
                            x=Random.Range(oldPosition.x-range,oldPosition.x +range);
                            y=Random.Range(oldPosition.y-range,oldPosition.y +range);
                            randomPosition = new Vector2(x,y);
                            randomMove = false;
                            z=0;
                            break;
                    }
                }else{
                    if(Time.time >= p+1||wait==true){
                    p=Time.time;
                    z=1;
                    waitf=Random.Range(1,4);
                    wait=false;
                    }
                }
            }if(Vector2.Distance(transform.position, randomPosition)!=0 && randomMove == false && arrived==false){
                transform.position = Vector2.MoveTowards(transform.position, randomPosition, speed * Time.deltaTime);
            }if(Vector2.Distance(transform.position, randomPosition)==0){
                 randomMove = true;
            }
        }   
    }
}
