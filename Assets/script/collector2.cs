using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collector2 : MonoBehaviour
{
    public GameObject isDeadMenu1;
    private void Start() {
        AdsManager.instance.RequestInterstitial();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("enemy")){
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("EnemyAttack");
        }
        if(other.CompareTag("nick")){
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("EnemyAttack");
            Pause();
        }
    }
    public void goBackToMenu(){
        Time.timeScale=1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void restart(){
        Time.timeScale=1f;
        SceneManager.LoadScene("SampleScene");
    }
    void Pause(){
        isDeadMenu1.SetActive(true);
        Time.timeScale=0f;
        AdsManager.instance.showInterstitial();
    }
    IEnumerator NickCoroutine(){
         yield return new WaitForSeconds(3);
         SceneManager.LoadScene("MainMenu");
    }
}
