using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
   public NavMeshAgent agent;
   Transform target;
   Animator anim;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        anim.SetBool("Run", true);
        anim.SetBool("Idling", false);
        anim.SetBool("Impact", false);
    }

    
    void Update()
    {
     agent.SetDestination(target.transform.position); 
    }
}
