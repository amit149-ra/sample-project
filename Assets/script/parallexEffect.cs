using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallexEffect : MonoBehaviour
{
    private float length,startPos;
    public GameObject cam;
    public float parallexEffe;
    // Start is called before the first frame update
    void Start()
    {
        startPos= transform.position.x;
        length=GetComponent<SpriteRenderer>().bounds.size.x;
        
    }
     void FixedUpdate() {
         float temp=(cam.transform.position.x*(1-parallexEffe));
        float dist=(cam.transform.position.x*parallexEffe);
        transform.position=new Vector3(startPos+dist,transform.position.y,transform.position.z);
        if (temp>startPos+length){startPos+=length;}else if(temp<startPos-length){startPos-=length;}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
