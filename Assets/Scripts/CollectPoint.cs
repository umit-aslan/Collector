using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectPoint : MonoBehaviour
{
    public GameObject collectText;
    public int counter = 0;
    TrapControl trapControlScript;
    public GameObject parent;
    StackManager stackManager;

    private void Start() {
        trapControlScript = FindObjectOfType<TrapControl>();
        stackManager = FindObjectOfType<StackManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StackArea"))
        {
            StartCoroutine(ICollect());
        }
        collectText.GetComponent<Text>().text = counter.ToString();
        Debug.Log(counter);
    }
    private void OnCollisionExit(Collision other)
    {
        stackManager.prevObject=GameObject.Find("Stack1").transform;
    }

    private IEnumerator ICollect()
     {
         for (int i = 1; i < parent.transform.childCount; i++)
         {
             counter++;
            Destroy(parent.transform.GetChild(i).gameObject);//Tüm öğeleri siler
           //parent.transform.GetChild(i).transform.parent=null;//Parent'ı sıfırla
         }
         yield return new WaitUntil(() => parent.transform.childCount == 0);//Çocuklarının silinmesi için beklemek gerekir.
     }   
}
