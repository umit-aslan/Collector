using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject healthText;
    public int health = 3;
    public GameObject gameOverPanel;
    
  private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "enemy")
        {
            health--;
            healthText.GetComponent<Text>().text =  health.ToString();
             if (health == 0) {
                Debug.Log("Game Over");
                gameOverPanel.SetActive(true);
                Time.timeScale = 0;
            } 
        }
    }
}
