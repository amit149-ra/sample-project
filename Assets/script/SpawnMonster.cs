using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReff; 
    private GameObject spawnMonster;
    [SerializeField]
    private Transform Left, Right;
    private int randomIndex, randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    // Update is called once per frame
    IEnumerator SpawnMonsters(){
       while(true){
            yield return new WaitForSeconds(Random.Range(2,6));
        randomIndex=Random.Range(0,1);
        randomSide=Random.Range(0,2);
        spawnMonster=Instantiate(monsterReff[0]);
        if (randomSide==0){ //randomSide==0
            spawnMonster.transform.position=Left.position;
            spawnMonster.GetComponent<EnemyScript>().speed=Random.Range(4,7);
            spawnMonster.GetComponent<EnemyScript>().directionCheck=true;
            spawnMonster.transform.position=new Vector3(spawnMonster.transform.position.x,spawnMonster.transform.position.y,0);
        }else{
            spawnMonster.transform.position=Right.position;
            spawnMonster.GetComponent<EnemyScript>().directionCheck=false;
            spawnMonster.GetComponent<EnemyScript>().speed=-Random.Range(4,7);
            // spawnMonster.GetComponent<enemy>().groundDetection=wff;
            spawnMonster.transform.localScale=new Vector3(-0.16f,0.16f,0);
            spawnMonster.transform.position=new Vector3(spawnMonster.transform.position.x,spawnMonster.transform.position.y,0);

        }
       }
    } 
}
