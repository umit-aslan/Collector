using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag=="Pick")
        {
            other.gameObject.tag="Stacks";
            StackManager.instance.PickUp(other.gameObject);
        }
    }
}