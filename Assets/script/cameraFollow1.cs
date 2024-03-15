using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow1 : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform nick;
    private Vector3 tempPos,tempVer;
    [SerializeField]
    private float minX,maxX;
    private bool a=true;
    public Vector3 camera1,posit;
    // Start is called before the first frame update
    void Start()
    {
        nick=GameObject.FindWithTag("nick").transform;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!nick){return;}
        
        tempPos=transform.position;
        tempPos.x=nick.position.x;
        transform.position=tempPos;


        if(tempPos.x<minX){
            tempPos.x=minX;
        }
        if(tempPos.x>maxX){
            tempPos.x=maxX;
        }

            
            transform.position=tempPos;

        // tempVer=transform.position;
        // tempVer.y=nick.position.y;
        // transform.position=tempVer;

        
    }
}
