using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveDataManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static saveDataManager instance;
    public GameObject nick1;
    public int score1;
    public int Highscore;
    private void Awake() {
        if(instance==null){
            instance=this;
            DontDestroyOnLoad(this);
        }else if(instance!=null){
            Destroy(this);
        }
       gameData data= saveSystem.loadPlayer();
        Highscore=data.score1; 
    }
    public void updatescrore(){
        if(!nick1)
        return;

        score1= nick1.GetComponent<nick>().score;

    }
    public void saveData(){
        if(Highscore<score1){
        saveSystem.savePlayer(this);
        }
    }
}
