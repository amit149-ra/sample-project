using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class nick : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 15f;
    [SerializeField]
    private float jumpForce = 15f;

    public int score;
    public TextMeshProUGUI m_TextComponent;

    public float movementX;
    public float movementY;
    public float fallMultiplier=2.5f,attackRange=0.5f;
    public float lowJumpMultiplier=2f;
   
    public Rigidbody2D myBody;
    public LayerMask enemyLayers;

    private SpriteRenderer sr;

    private Animator anim;
    public Transform attackTransfromation;
    private string WAlk="walk";
    private string GROUND_TAG="Ground",GROUND_TAG1="Ground2",EnemyTag="enemy";

    private bool isGrounded=true;
    private bool isGrounded2=true;

    public GameObject isDeadMenu;



    public delegate void KillThem();
    public static event KillThem killthem;

    




    private void Awake(){
        myBody=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        sr=GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        AdsManager.instance.RequestInterstitial();
        score=0;
    }

    // Update is called once per frame
   void Update()
    {
        moveTheCatKeyboards();
        AnimateCate();
        // CatJump();
        // Attack();
        Straight();
        
    }
    void Straight(){
        Vector3 rotationVector = transform.rotation.eulerAngles;

         rotationVector.x = 0;

         rotationVector.z = 0;

           transform.rotation = Quaternion.Euler(rotationVector);
    }

    public void Attack(){
        if(Input.GetButtonUp("Fire1")){
            Attack1();
        }
        Attack1();
    }
    void Attack1(){
        anim.SetTrigger("Attack");
        FindObjectOfType<AudioManager>().Play("FAttack");
        Collider2D[] hitEnemy=Physics2D.OverlapCircleAll(attackTransfromation.position,attackRange,enemyLayers);
        foreach(Collider2D enemy in hitEnemy){
            score++;
            enemy.GetComponent<EnemyScript>().Die();
            m_TextComponent.SetText(score.ToString());
            saveDataManager.instance.updatescrore();
            saveDataManager.instance.saveData();
        }
    }
    
    void moveTheCatKeyboards(){
        transform.position+= new Vector3(movementX,0f,0f)*Time.deltaTime*moveForce;
        transform.position+= new Vector3(movementY,0f,0f)*Time.deltaTime*moveForce;


    }
    void AnimateCate(){
        if(movementX>0){
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool(WAlk,true);
        }
        else if(movementY<0){
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool(WAlk,true);
        }
        else{
            anim.SetBool(WAlk,false);
        }
    }

    public void CatJump(){
        Debug.Log("what the fuvk");
        if(isGrounded||isGrounded2){
                if(myBody.velocity.y<0){
                myBody.velocity+= Vector2.up *Physics2D.gravity.y * (fallMultiplier-1)* Time.deltaTime;
                   }else if(myBody.velocity.y>0 && !Input.GetButton("Jump")){
            myBody.velocity+=Vector2.up*Physics2D.gravity.y* (lowJumpMultiplier-1) *Time.deltaTime;
            }
        }
        
    }
    // void CatJump(){
        // if(myBody.velocity.y<0){
        // myBody.velocity+= Vector2.up *Physics2D.gravity.y * (fallMultiplier-1)* Time.deltaTime;
        // }else if(myBody.velocity.y>0 && !Input.GetButton("Jump")){
        //     myBody.velocity+=Vector2.up*Physics2D.gravity.y* (lowJumpMultiplier-1) *Time.deltaTime;
        //     }
    // }
    private void OnCollisionEnter2D(Collision2D collision) {
    if(collision.gameObject.CompareTag(GROUND_TAG)){
        isGrounded=true;
        Debug.Log("nick landed");
    }else if(collision.gameObject.CompareTag(GROUND_TAG1)){
        isGrounded2=true;
        Debug.Log("nick landed");
    }
    if(collision.gameObject.CompareTag(EnemyTag)){
        Destroy(gameObject);
        if(killthem!=null){
            killthem();
        }
        // StartCoroutine(NickCoroutine1());
        // SceneManager.LoadScene("MainMenu");
        // AdsManager.instance.showInterstitial();
        Pause();
    }
    }

    void Pause(){
        isDeadMenu.SetActive(true);
        Time.timeScale=0f;
        AdsManager.instance.showInterstitial();
    }

    IEnumerator NickCoroutine1(){
         yield return new WaitForSeconds(3);
         SceneManager.LoadScene("MainMenu");
    }
}
