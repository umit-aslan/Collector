using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject GameOverPanel;
    public GameObject GameWinPanel;
    public GameObject GameWinPanelScoreText;
    CollectPoint collectPoint;
    AudioSource audioSource;
   public AudioClip[] audioClips;
   private void Start()
   {
       Time.timeScale = 0;
       audioSource = GetComponent<AudioSource>();
       collectPoint = FindObjectOfType<CollectPoint>();
   }
   public void GameStart()
   {
        Time.timeScale = 1;
        startPanel.SetActive(false);
   }
   public void GameRestart()
   {
        SceneManager.LoadScene(0);  
   }

   public void GameWin()
   {
        GameWinPanelScoreText.GetComponent<Text>().text = "Score: " + collectPoint.counter.ToString();
        GameWinPanel.SetActive(true);
        Time.timeScale = 0;
        audioSource.PlayOneShot(audioClips[0]);
   }

   public void GameOver()
   {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
        audioSource.PlayOneShot(audioClips[1]);
   }


}
