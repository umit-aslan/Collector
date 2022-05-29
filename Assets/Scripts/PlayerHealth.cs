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
    
    private void Start() {
        collectPointScript=FindObjectOfType<CollectPoint>();
    }

  private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "enemy")
        {
            health--;
            healthText.GetComponent<Text>().text =  health.ToString();
             if (health == 0) {
                Debug.Log("Game Over");
                GameOvercollectText.GetComponent<Text>().text = collectPointScript.counter.ToString();
                gameOverPanel.SetActive(true);
                Time.timeScale = 0;
            } 
        }
    }
}
