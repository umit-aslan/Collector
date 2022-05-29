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
        collectPointScript=FindObjectOfType<CollectPoint>();
        game_ManagerScript=FindObjectOfType<Game_Manager>();
        audioSource=GetComponent<AudioSource>();
    }

  private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "enemy")
        {
            audioSource.PlayOneShot(audioClips[0]);
            health--;
            healthText.GetComponent<Text>().text =  health.ToString();
             if (health == 0) {
                Debug.Log("Game Over");
                GameOvercollectText.GetComponent<Text>().text = collectPointScript.counter.ToString();
                game_ManagerScript.GameOver();
            } 
        }
    }
}
