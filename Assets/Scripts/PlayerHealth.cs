using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject healthText;
    public GameObject GameOvercollectText;
    public int health = 3;
    public GameObject gameOverPanel;
    CollectPoint collectPointScript;
    Game_Manager game_ManagerScript;
    public AudioClip[] audioClips;
    AudioSource audioSource;
    
    private void Start() {
        collectPointScript=FindObjectOfType<CollectPoint>();//collectPointScript'e erişiyoruz
        game_ManagerScript=FindObjectOfType<Game_Manager>();//game_ManagerScript'e erişiyoruz
        audioSource=GetComponent<AudioSource>();//audioSource'a erişiyoruz
    }

    public void healthWarning()
    {
        audioSource.PlayOneShot(audioClips[0]);//İndex 0'ın sesini çalıyoruz
            health--;//health'i 1 azaltıyoruz
            healthText.GetComponent<Text>().text =  health.ToString();//healthText'e health'i yazdırıyoruz
             if (health == 0) {
                //Debug.Log("Game Over");
                GameOvercollectText.GetComponent<Text>().text = collectPointScript.counter.ToString();
                game_ManagerScript.GameOver();//GameOver fonksiyonunu çalıştırıyoruz.
            } 
    }
}
