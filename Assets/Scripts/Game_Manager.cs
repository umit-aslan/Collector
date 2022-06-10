using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject GameOverPanel;
    public GameObject GameOverPanelScoreText;
    public GameObject GameWinPanel;
    public GameObject GameWinPanelScoreText;
    CollectPoint collectPoint;
    AudioSource audioSource;
   public AudioClip[] audioClips;
   private void Start()
   {
       Time.timeScale = 0;
       audioSource = GetComponent<AudioSource>();//AudioSource'ı alır
       collectPoint = FindObjectOfType<CollectPoint>();//CollectPoint scriptini alır
   }
   public void GameStart()
   {
        Time.timeScale = 1;
        startPanel.SetActive(false);//StartPanel'ı kapat
   }
   public void GameRestart()
   {
        SceneManager.LoadScene(0);//Scene'i yeniden yükler
   }

   public void GameWin()
   {
        GameWinPanelScoreText.GetComponent<Text>().text = "Score: " + collectPoint.counter.ToString();
        GameWinPanel.SetActive(true);//GameWinPanel'ı aktif hale getirir
        Time.timeScale = 0;
        audioSource.PlayOneShot(audioClips[0]);//GameWin sesini çalar
   }

   public void GameOver()
   {
        GameOverPanelScoreText.GetComponent<Text>().text = "Score: " + collectPoint.counter.ToString();//GameOverPanelScoreText'e skoru yazdırır
        GameOverPanel.SetActive(true);//GameOverPanel'ı aktif hale getirir
        Time.timeScale = 0;
        audioSource.PlayOneShot(audioClips[1]);//GameOver sesini çalar
   }
}
