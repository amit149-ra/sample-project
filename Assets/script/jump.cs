using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    [Range(1,10)]
    public float jumpVelocity;
    public bool isGrounded=true;
    private string GROUND_TAG="Ground";
    public bool isGrounded2=true;
    private string GROUND_TAG1="Ground2";

    // Update is called once per frame
    void Update()
    {
       
    }

    public void JumpMatherFucker(){
         if(isGrounded){
            GetComponent<Rigidbody2D>().velocity=Vector2.up*jumpVelocity;
             isGrounded=false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
    if(collision.gameObject.CompareTag(GROUND_TAG)){
        isGrounded=true;
        Debug.Log("Cat landed");
    }else if(collision.gameObject.CompareTag(GROUND_TAG1)){
        isGrounded=true;
        Debug.Log("Cat landed");
    }else if(collision.gameObject.CompareTag("stone")){
        isGrounded=true;
        Debug.Log("Cat landed");
    }
    }
}

