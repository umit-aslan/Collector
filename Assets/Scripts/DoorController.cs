using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject stackPool;
    Animation anim;

    void Start()
    {
        //this.GetComponent<Animation>().Play("Door");
        
    }
   private void OnTriggerEnter(Collider other) 
   {
     if (other.gameObject.tag == "Player")
     {
        Debug.Log("Player entered");
        anim.Play();
     }
   }
}
