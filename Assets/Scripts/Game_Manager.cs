using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public GameObject startPanel;
   private void Start()
   {
       Time.timeScale = 0;
   }
   public void GameStart()
   {
        Time.timeScale = 1;
        startPanel.SetActive(false);
   }
}
