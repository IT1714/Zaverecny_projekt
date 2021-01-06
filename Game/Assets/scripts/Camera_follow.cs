using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        //pozice kamery
        Vector3 temp = transform.position;
        //pozice x kamery = pozice x player
        temp.x=playerTransform.position.x;
        //pozice x kamery = pozice x player
        temp.y=playerTransform.position.y;
        transform.position = temp;
    }
}