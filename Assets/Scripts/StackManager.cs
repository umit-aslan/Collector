using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public static StackManager instance;//Diğer scriptlerden buraya erişebilmek için static olarak tanımladık.
    [SerializeField] private float  distanceBetweenStacks;//Stacklar arasındaki mesafe.
    public  Transform prevObject;//Önceki stack.
    [SerializeField] private Transform parent;//Stackların ekleneceği parent.

    private void Awake() {
        if (instance == null) //instance null ise
        {
            instance = this;//instance'ı bu script'e ata.
        }   
    }
    void Start()
    {
        distanceBetweenStacks=prevObject.localScale.y;//Önceki stack'in yüksekliğini al.
    }

    public void PickUp (GameObject  pickedObject,bool downOrUp=true)
    {
      //pickedObject= çarpılan obje, needTag=çarpılan objekt tag'i gerekli mi, tag=tag ise ne olacak, downOrUp=
      
        pickedObject.transform.parent=parent;//Parent'a ata.
        Vector3 desPos=prevObject.localPosition;//Önceki stack'in pozisyonunu al.
        desPos.y+=downOrUp?distanceBetweenStacks:-distanceBetweenStacks;//Yukarı veya aşağı yukarı ise yukarıya, aşağı ise aşağıya ata.
        pickedObject.transform.localPosition=desPos;//Pozisyonu ata.
        pickedObject.transform.localRotation=Quaternion.identity;//Döndürmeyi sıfırla.
        prevObject=pickedObject.transform;//Önceki stack'i ata.  
  }
}
