using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
   public NavMeshAgent agent;
   Transform target;
   Animator anim;
   public float distance;
   public float turnSpeed = 3.0f;
   public bool isDeadPlayer=false;
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
     FollowPlayer();
    }

    public void FollowPlayer()
    {       
        distance = Vector3.Distance(transform.position, target.position);
        
        if (distance<60&&distance>10&&isDeadPlayer==false)
        {
        agent.updateRotation = true;
        agent.SetDestination(target.transform.position);
        agent.updatePosition = true;
        anim.SetBool("Idling", false);
        anim.SetBool("Impact", false); 
        anim.SetBool("Run", true);  
        }
        else if (distance<=10&&isDeadPlayer==false)
        {
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
        agent.updatePosition = false;
        anim.SetBool("Run", false);
        anim.SetBool("Impact", true);  
        
        }
        else if (distance>=60)
        {           
            anim.SetBool("Idling", true);
            anim.SetBool("Impact", false);  
            anim.SetBool("Run", false); 
        }
        else if(isDeadPlayer)
        {
            anim.SetBool("Attack", false);
            anim.SetBool("isWalking", false);
            Debug.Log("Player is Dead. Zombie  Win");
            target.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
       
    }

}
