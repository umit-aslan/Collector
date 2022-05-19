using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapControl : MonoBehaviour
{
    public GameObject parent;
    StackManager stackManager;
     void Start() {
        stackManager = FindObjectOfType<StackManager>();
    }
   private void OnCollisionEnter(Collision other) {
       if (other.gameObject.CompareTag("trap"))
       {
          Debug.Log("Trap");
          StartCoroutine(IClearItems());
          
       } 
   }
   private void OnCollisionExit(Collision other) {
       stackManager.prevObject=GameObject.Find("Stack1").transform;
   }
   private IEnumerator IClearItems()
     {
         for (int i = 1; i < parent.transform.childCount; i++)
         {
             
         Destroy(parent.transform.GetChild(i).gameObject);  
         }
         yield return new WaitUntil(() => parent.transform.childCount == 0);
        
         // Code to initialize your new items
     }
   
}
