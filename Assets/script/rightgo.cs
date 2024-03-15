using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class rightgo : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    bool Ispressed;
    public GameObject nick;
    void Update()
    {
        if(!nick){return;}
        if(Ispressed){
            nick.GetComponent<nick>().movementX=1f;
            }else{
                nick.GetComponent<nick>().movementX=0f;
            }
    }
    
    public void OnPointerDown(PointerEventData eventData){
        Ispressed=true;
    }
    public void OnPointerUp(PointerEventData eventData){
        Ispressed=false;
    }

}