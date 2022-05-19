using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapControl : MonoBehaviour
{
    public GameObject parent;
    StackManager stackManager;
    Mover mover;
    void Start() {
        stackManager = FindObjectOfType<StackManager>();
        mover = FindObjectOfType<Mover>();
    }
   private void OnCollisionEnter(Collision other) {
       if (other.gameObject.CompareTag("trap"))
       {
          Debug.Log("Trap");
          mover.animator.SetBool("Impact", true);
          mover.animator.SetBool("Idling", false);
          mover.animator.SetBool("Run", false);
          mover.transform.position = Vector3.MoveTowards(transform.position,Vector3.Lerp(Vector3.back, transform.position, 0.5f), mover.speed * Time.deltaTime);
          StartCoroutine(IClearItems());
          
       } 
   }
   private void OnCollisionExit(Collision other) {
       stackManager.prevObject=GameObject.Find("Stack1").transform;
        mover.animator.SetBool("Impact", false);
        mover.animator.SetBool("Idling", true);
        mover.animator.SetBool("Run", false);
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
