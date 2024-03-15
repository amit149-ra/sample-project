using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class leftgo : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    bool Ispress;
    public GameObject nick1;
    void Update()
    {
        if(!nick1){return;}
        if(Ispress){
            nick1.GetComponent<nick>().movementY=-1f;
            }else{
                nick1.GetComponent<nick>().movementY=0f;
            }
    }

    public void OnPointerDown(PointerEventData eventData){
        Ispress=true;
        // nick1.GetComponent<nick>().movementX=1f;
        Debug.Log("successs");
    }
    public void OnPointerUp(PointerEventData eventData){
        Ispress=false;
        // nick1.GetComponent<nick>().movementX=0f;
        Debug.Log("Failure");
    }
}
