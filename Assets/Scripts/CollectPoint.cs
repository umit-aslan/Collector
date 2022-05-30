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
    public GameObject stackObjectParent;
    Game_Manager game_ManagerScript;

    private void Start() {
        trapControlScript = FindObjectOfType<TrapControl>();
        stackManager = FindObjectOfType<StackManager>();
        game_ManagerScript = FindObjectOfType<Game_Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StackArea"))
        {
            StartCoroutine(ICollect());
            if (stackObjectParent.transform.childCount == 0)
            {
                game_ManagerScript.GameWin();
            }
        }
        
        Debug.Log(counter);
    }
    private void OnCollisionExit(Collision other)
    {
        stackManager.prevObject=GameObject.Find("Stack1").transform;
        collectText.GetComponent<Text>().text = counter.ToString();
    }

    private IEnumerator ICollect()
     {
         for (int i = 1; i < parent.transform.childCount; i++)
         {
            counter+=10;
            Destroy(parent.transform.GetChild(i).gameObject);//Tüm öğeleri siler
           //parent.transform.GetChild(i).transform.parent=null;//Parent'ı sıfırla
         }
         yield return new WaitUntil(() => parent.transform.childCount == 0);//Çocuklarının silinmesi için beklemek gerekir.
     }   
}
