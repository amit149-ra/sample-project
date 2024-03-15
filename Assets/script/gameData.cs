using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class gameData
{
    public int score1;
    public gameData(saveDataManager nick){
        score1=nick.score1;
    }
}
