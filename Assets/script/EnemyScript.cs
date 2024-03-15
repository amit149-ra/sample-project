using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
   public int speed,c_speed;
    private Rigidbody2D enemies;
    public float distance,jumpForce;
    private string GROUND_TAG="Ground";
    private string GROUND2_TAG="Ground2";
    public bool isGrounded=false,isGrounded2=false;
    public bool directionCheck;
    public int jumpingSpeedManager;
    private Animator anima;
    // Start is called before the first frame update
    void Awake()
    {
        enemies=GetComponent<Rigidbody2D>();
        anima=GetComponent<Animator>();
        
    }
    void Start(){
        // speed=Random.Range(4,7);
        // if(directionCheck==false){
        //     speed=-1*speed;
        // } else if(directionCheck==true){
        //     this.speed=speed;
        // }
        c_speed=speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemies.velocity=new Vector2(speed,enemies.velocity.y);
    }

    public void jumping(float x){
        Debug.Log("jumping");
        enemies.AddForce(new Vector2(0, x),ForceMode2D.Impulse);
        // if(isGrounded==false && speed==4){
        //     speed=8;
        // }
        jumpSpeedManagement();
    }

    public void Die(){
        Debug.Log("die animation");
        anima.SetTrigger("isDie");
        FindObjectOfType<AudioManager>().Play("EnemyAttack");
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        GetComponent<CapsuleCollider2D>().enabled=false;
        this.enabled= false;
        StartCoroutine(ExampleCoroutine());
        
    }

    IEnumerator ExampleCoroutine(){
         yield return new WaitForSeconds(1);
         Destroy(gameObject);
    }


    void OnEnable() {
        nick.killthem+=Die;
    }
    private void OnDisable() {
        nick.killthem-=Die;
    }


    void jumpSpeedManagement(){
        if(jumpingSpeedManager==1){
            if(isGrounded==false && speed==4){
            speed=8;
            }else if(isGrounded==false && speed==5){
            speed=7;
            }else if(isGrounded==false && speed==6){
            speed=8;
            }
        }
        if(jumpingSpeedManager==2){
            if(isGrounded==false && speed==4){
            speed=7;
            }else if(isGrounded==false && speed==5){
            speed=6;
            }else if(isGrounded==false && speed==6){
            speed=6;
            }
        }
        if(jumpingSpeedManager==3){
            if(isGrounded==false && speed==4){
            speed=6;
            }else if(isGrounded==false && speed==5){
            speed=6;
            }else if(isGrounded==false && speed==6){
            speed=6;
            }else if(isGrounded==false && speed==7){
            speed=6;
            }
        }
        if(jumpingSpeedManager==4){
            if(isGrounded==false && speed==4){
            speed=6;
            }else if(isGrounded==false && speed==5){
            speed=6;
            }else if(isGrounded==false && speed==6){
            speed=6;
            }else if(isGrounded==false && speed==7){
            speed=6;
            }
        }
        if(jumpingSpeedManager==5){
            if(isGrounded==false && speed==4){
            speed=6;
            }else if(isGrounded==false && speed==5){
            speed=5;
            }else if(isGrounded==false && speed==6){
            speed=6;
            }else if(isGrounded==false && speed==7){
            speed=5;
            }
        }
        if(jumpingSpeedManager==6){
            if(isGrounded2==false && speed==-4){
            speed=-7;
            }else if(isGrounded2==false && speed==-5){
            speed=-7;
            }else if(isGrounded2==false && speed==-6){
            speed=-7;
            }else if(isGrounded2==false && speed==-7){
            speed=-7;
            }
        }
        if(jumpingSpeedManager==7){
            if(isGrounded2==false && speed==-4){
            speed=-7;
            }else if(isGrounded2==false && speed==-5){
            speed=-7;
            }else if(isGrounded2==false && speed==-6){
            speed=-7;
            }else if(isGrounded2==false && speed==-7){
            speed=-7;
            }
        }
        if(jumpingSpeedManager==8){
            if(isGrounded2==false && speed==-4){
            speed=-7;
            }else if(isGrounded2==false && speed==-5){
            speed=-7;
            }else if(isGrounded2==false && speed==-6){
            speed=-7;
            }else if(isGrounded2==false && speed==-7){
            speed=-7;
            }
        }
        if(jumpingSpeedManager==9){
            if(isGrounded2==false && speed==-4){
            speed=-7;
            }else if(isGrounded2==false && speed==-5){
            speed=-7;
            }else if(isGrounded2==false && speed==-6){
            speed=-7;
            }else if(isGrounded2==false && speed==-7){
            speed=-7;
            }
        }
        if(jumpingSpeedManager==10){
            if(isGrounded2==false && speed==-4){
            speed=-6;
            }else if(isGrounded2==false && speed==-5){
            speed=-6;
            }else if(isGrounded2==false && speed==-6){
            speed=-6;
            }else if(isGrounded2==false && speed==-7){
            speed=-6;
            }
        }
        if(jumpingSpeedManager==11){
            if(isGrounded2==false && speed==-4){
            speed=-6;
            }else if(isGrounded2==false && speed==-5){
            speed=-6;
            }else if(isGrounded2==false && speed==-6){
            speed=-6;
            }else if(isGrounded2==false && speed==-7){
            speed=-6;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
    if(collision.gameObject.CompareTag(GROUND_TAG)){
        isGrounded=true;
        isGrounded2=false;
        speed=c_speed;
        Debug.Log("Enemy Landed");
    }else if(collision.gameObject.CompareTag(GROUND2_TAG)){
        isGrounded=false;
        isGrounded2=true;
        speed=c_speed;
        Debug.Log("enemy doe");
    }
    }


    public void enemyjump(){
        Debug.Log("enemy Jumped");
        if(speed==4){
            jumping(7f);
        }else if(speed==5){
            jumping(6f);
        }else if(speed==6){
            jumping(6.5f);
        }else if(speed==7){
            jumping(6.3f);
        }
    }
    public void enemyjump1(){
        Debug.Log("enemy Jumped1");
        if(speed==4){
            jumping(10f);
        }else if(speed==5){
            jumping(7.5f);
        }else if(speed==6){
            jumping(6f);
        }else if(speed==7){
            jumping(6f);
        }else if(speed==8){
            
        }
    }
    public void enemyjump2(){
        Debug.Log("enemy Jumped2");
        if(speed==4){
            jumping(8f);
        }else if(speed==5){
            jumping(9f);
        }else if(speed==6){
            jumping(8f);
        }else if(speed==7){
            jumping(10f);
        }else if(speed==8){
            
        }
    }
    public void enemyjump3(){
        Debug.Log("enemy Jumped3");
        if(speed==4){
            jumping(8f);
        }else if(speed==5){
            jumping(8f);
        }else if(speed==6){
            jumping(8f);
        }else if(speed==7){
            jumping(8f);
        }else if(speed==8){
            
        }
    }
    public void enemyjump4(){
        Debug.Log("enemy Jumped4");
        if(speed==4){
            jumping(8f);
        }else if(speed==5){
            jumping(8f);
        }else if(speed==6){
            jumping(8f);
        }else if(speed==7){
            jumping(8f);
        }else if(speed==8){
            
        }
    }
    public void enemyjump5(){
        Debug.Log("enemy Jumped5");
        if(speed==4){
            jumping(8f);
        }else if(speed==5){
            jumping(9f);
        }else if(speed==6){
            jumping(8f);
        }else if(speed==7){
            jumping(8f);
        }else if(speed==8){
            
        }
    }
    public void enemyjump6(){
        Debug.Log("enemy Jumped6");
        if(speed==4){
            jumping(10f);
        }else if(speed==5){
            jumping(10f);
        }else if(speed==6){
            jumping(10f);
        }else if(speed==7){
            jumping(9f);
        }else if(speed==8){
            
        }
    }






    
     public void renemyjump0(){
        Debug.Log("enemy Jumped");
        if(speed==-4){
            jumping(4f);
        }else if(speed==-5){
            jumping(4f);
        }else if(speed==-6){
            jumping(4f);
        }else if(speed==-7){
            jumping(4f);
        }
    }
    public void renemyjump(){
        Debug.Log("enemy Jumped");
        if(speed==-4){
            jumping(10f);
        }else if(speed==-5){
            jumping(10f);
        }else if(speed==-6){
            jumping(10f);
        }else if(speed==-7){
            jumping(10f);
        }
    }
    public void renemyjump1(){
        Debug.Log("enemy Jumped");
        if(speed==-4){
            jumping(6f);
        }else if(speed==-5){
            jumping(6f);
        }else if(speed==-6){
            jumping(6f);
        }else if(speed==-7){
            jumping(6f);
        }
    }
    public void renemyjump2(){
        Debug.Log("enemy Jumped");
        if(speed==-4){
            jumping(10f);
        }else if(speed==-5){
            jumping(10f);
        }else if(speed==-6){
            jumping(10f);
        }else if(speed==-7){
            jumping(10f);
        }
    }
    public void renemyjump3(){
        Debug.Log("enemy Jumped");
        if(speed==-4){
            jumping(8.5f);
        }else if(speed==-5){
            jumping(8.5f);
        }else if(speed==-6){
            jumping(8.5f);
        }else if(speed==-7){
            jumping(8.5f);
        }
    }
    public void renemyjump4(){
        Debug.Log("enemy Jumped");
        if(speed==-4){
            jumping(4f);
        }else if(speed==-5){
            jumping(4f);
        }else if(speed==-6){
            jumping(4f);
        }else if(speed==-7){
            jumping(4f);
        }
    }
}
