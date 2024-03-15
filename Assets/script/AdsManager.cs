using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdsManager : MonoBehaviour
{
    private InterstitialAd interstitial;
    public static AdsManager instance;
    public void Awake() {
        if(instance==null){
            instance=this;
        }else{
            Destroy(gameObject);
            return;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(InitializationStatus=>{});

    }
    private AdRequest CreateAdRequest(){
        return new AdRequest.Builder().Build();
    }


    public void RequestInterstitial()
{
    string adUnitId = "ca-app-pub-1990748177829774/2580547874";
    if (this.interstitial!=null){
        this.interstitial.Destroy();
    }
    this.interstitial = new InterstitialAd(adUnitId);

    this.interstitial.LoadAd(this.CreateAdRequest());
}
public void showInterstitial(){
    if(this.interstitial.IsLoaded()){
         Debug.Log("interstitial is not ready yet:Mission complete");
        interstitial.Show();
    }else{
        Debug.Log("interstitial is not ready yet");
    }
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
