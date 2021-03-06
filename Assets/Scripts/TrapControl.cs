using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapControl : MonoBehaviour
{
    public GameObject parent;
    StackManager stackManager;
    Mover mover;
    PlayerHealth playerHealth;
    void Start() {
        stackManager = FindObjectOfType<StackManager>();//stackManager script
        mover = FindObjectOfType<Mover>();//mover script
        playerHealth = FindObjectOfType<PlayerHealth>();//playerHealth   script
    }
   private void OnCollisionEnter(Collision other) {
       if (other.gameObject.CompareTag("trap")||other.gameObject.CompareTag("enemy"))
       {
          playerHealth.healthWarning();
          mover.animator.SetBool("Impact", true);//Impact animasyonunu çalıştırılır.
          mover.animator.SetBool("Idling", false);//Idling animasyonu çalışıyorsa kapat.
          mover.animator.SetBool("Run", false);//Run animasyonu çalışıyorsa kapat.
          mover.transform.position = Vector3.MoveTowards(transform.position,Vector3.Lerp(Vector3.back, transform.position, 0.5f), mover.speed * Time.deltaTime);
          StartCoroutine(IClearItems());
          
       } 
   }
   private void OnCollisionExit(Collision other) {
        stackManager.prevObject=GameObject.Find("Stack1").transform;
        StartCoroutine(ImpactEffect());//start coroutine
   }
   private IEnumerator IClearItems()
     {
         for (int i = 1; i < parent.transform.childCount; i++)
         {
             
          Destroy(parent.transform.GetChild(i).gameObject);//Tüm öğeleri siler
           //parent.transform.GetChild(i).transform.parent=null;//Parent'ı sıfırla
         }
         yield return new WaitUntil(() => parent.transform.childCount == 0);//Çocuklarının silinmesi için beklemek gerekir.
     }
     IEnumerator ImpactEffect()
     {
        yield return new WaitForSeconds(.5f);//0.5 saniye bekle
        mover.animator.SetBool("Impact", false);//Impact animasyonunu kapat
        mover.animator.SetBool("Idling", true);//Idling animasyonunu aç
        mover.animator.SetBool("Run", false);//Run animasyonunu kapat
     }
}
    
