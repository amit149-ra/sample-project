using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
 using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject playbutton;
    public GameObject Music;
    public GameObject Share;
    public GameObject can1;
    public GameObject can2;
    public GameObject settin;
    public GameObject quitd;
    public GameObject backb;
    public int score;
    [SerializeField]
    private Text score1txt;
     string subject = "add any text here ";
 string body = "https://play.google.com/store/apps/details?id=com.GimiTech.ShadowBug";

 private void Awake() {
        
    }
    public void LoadData(){
        gameData data= saveSystem.loadPlayer();
        score=data.score1;
        score1txt.text="SCORE: "+score;

    }

    public void PlayGame(){
        playbutton.SetActive(false);
        can1.SetActive(true);
        Music.SetActive(false);
        Share.SetActive(false);
        backb.SetActive(true);
        quitd.SetActive(false);
        LoadData();
    }
    public void QuitGame(){
        Debug.Log("game quit");
        Application.Quit();
    }
    public void setting(){
        playbutton.SetActive(false);
        Music.SetActive(false);
        Share.SetActive(false);
        quitd.SetActive(false);
        settin.SetActive(false);
        can1.SetActive(false);
        can2.SetActive(true);
        backb.SetActive(true);
    }
    public void Level1(){
        SceneManager.LoadScene("SampleScene");
    }
    public void music(){

    }
    public void share(){
        StartCoroutine(ShareAndroidText());
    }
    public void canva1(){
        
    }
    public void back(){
        playbutton.SetActive(true);
        Music.SetActive(true);
        Share.SetActive(true);
        quitd.SetActive(true);
        settin.SetActive(true);
        can1.SetActive(false);
        can2.SetActive(false);
        backb.SetActive(false);
    }

    IEnumerator ShareAndroidText()
 {
     yield return new WaitForEndOfFrame();
     //execute the below lines if being run on a Android device
     //Reference of AndroidJavaClass class for intent
     AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
     //Reference of AndroidJavaObject class for intent
     AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
     //call setAction method of the Intent object created
     intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
     //set the type of sharing that is happening
     intentObject.Call<AndroidJavaObject>("setType", "text/plain");
     //add data to be passed to the other activity i.e., the data to be sent
     intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
     intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TITLE"), "TITLE");
     intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), subject);
     intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), body);
     //get the current activity
     AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
     AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
     //start the activity by sending the intent data
     AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Share Via");
     currentActivity.Call("startActivity",jChooser);
 }
}
