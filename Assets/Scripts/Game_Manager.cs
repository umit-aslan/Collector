using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject GameOverPanel;
    AudioSource audioSource;
   private void Start()
   {
       Time.timeScale = 0;
        audioSource = GetComponent<AudioSource>();
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
}
