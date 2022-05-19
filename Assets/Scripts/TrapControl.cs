using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapControl : MonoBehaviour
{
   private void OnCollisionEnter(Collision other) {
       if (other.gameObject.CompareTag("trap"))
       {
           gameObject.GetComponentInParent<StackManager>().PickUp(other.gameObject,false);
           Destroy(other.gameObject,0.5f);
       }
       
   }
}
