using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScreanRes : MonoBehaviour
{
    public bool MaitainWidth = true;
    float defaultWidth;
    float defaultHight;
    Vector3 CameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        CameraPosition = Camera.main.transform.position;
        defaultHight =Camera.main.orthographicSize;
        defaultWidth = Camera.main.orthographicSize*Camera.main.aspect;

    }

    // Update is called once per frame
    void Update()
    {
        if(MaitainWidth){
            Camera.main.orthographicSize=defaultWidth/Camera.main.aspect;
            Camera.main.transform.position= new Vector3(CameraPosition.x, -1*(defaultHight-Camera.main.orthographicSize),CameraPosition.z);
        }else{

        }
    }
}
