using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscript : MonoBehaviour
{
    // public EnemyScript myenemy;
    public GameObject prenemy;
    // Start is called before the first frame update
    void Start()
    {
        prenemy=GameObject.FindWithTag("enemy");
        if(!prenemy)
        return;
        EnemyScript other=(EnemyScript) prenemy.GetComponent(typeof(EnemyScript));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other) {
        if(other.name=="enemy1(Clone)" && other.GetComponent<EnemyScript>().speed>0){
            if(name=="leftJumpsd"){
                Debug.Log("1");
                other.GetComponent<EnemyScript>().enemyjump();
            }else if(name=="leftJumpsd1"){
                Debug.Log("2");
                other.GetComponent<EnemyScript>().enemyjump1();
            }else if(name=="leftJumpsd2"){
                Debug.Log("3");
                other.GetComponent<EnemyScript>().jumpingSpeedManager=1;
                other.GetComponent<EnemyScript>().enemyjump2();
            }else if(name=="leftJumpsd3"){
                other.GetComponent<EnemyScript>().jumpingSpeedManager=2;
                other.GetComponent<EnemyScript>().enemyjump3();
                Debug.Log("4");
            }else if(name=="leftJumpsd4"){
                other.GetComponent<EnemyScript>().jumpingSpeedManager=3;
                other.GetComponent<EnemyScript>().enemyjump4();
                Debug.Log("5");
            }else if(name=="leftJumpsd5"){
                other.GetComponent<EnemyScript>().jumpingSpeedManager=4;
                other.GetComponent<EnemyScript>().enemyjump5();
                Debug.Log("6");
            }else if(name=="leftJumpsd6"){
                other.GetComponent<EnemyScript>().jumpingSpeedManager=5;
                other.GetComponent<EnemyScript>().enemyjump6();
                Debug.Log("7");
            }
            Debug.Log("Enemy jump");
        }
        if(other.name=="enemy1(Clone)" && other.GetComponent<EnemyScript>().speed<0){
            if(name=="rightjumped"){
                other.GetComponent<EnemyScript>().jumpingSpeedManager=6;
                other.GetComponent<EnemyScript>().renemyjump();
            }else if(name=="rightjumped1"){
                other.GetComponent<EnemyScript>().jumpingSpeedManager=7;
                other.GetComponent<EnemyScript>().renemyjump1();
            }else if(name=="rightjumped2"){
                other.GetComponent<EnemyScript>().jumpingSpeedManager=8;
                other.GetComponent<EnemyScript>().renemyjump2();
            }else if(name=="rightjumped3"){
                other.GetComponent<EnemyScript>().jumpingSpeedManager=9;
                other.GetComponent<EnemyScript>().renemyjump3();
            }else if(name=="rightjumped4"){
                other.GetComponent<EnemyScript>().jumpingSpeedManager=10;
                other.GetComponent<EnemyScript>().renemyjump4();
            }else if(name=="rightjumped0"){
                other.GetComponent<EnemyScript>().jumpingSpeedManager=11;
                other.GetComponent<EnemyScript>().renemyjump0();
            }
        }
    
    }
}
