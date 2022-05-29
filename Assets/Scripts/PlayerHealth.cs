using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject healthText;
    public int health = 3;

    
  private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            health--;
            healthText.GetComponent<Text>().text = "Health: " + health;
        }
    }
}
