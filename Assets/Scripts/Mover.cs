using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Camera cam;
    private Animator animator;
    public   float  turnSpeed, speed, lerpValue;
    public   LayerMask layer;
    void Start() 
    {
       cam = Camera.main;
       animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Movement();
        }
        else
        {
            if (animator.GetBool("Run"))
            {
                animator.SetBool("Run", false);
            }
        }
    }

    private void Movement()
    {
        Vector3  mousePos = Input.mousePosition;
        mousePos.z = cam.transform.localPosition.y;

        Ray ray=cam.ScreenPointToRay(mousePos);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
        {
            Vector3 hitVec = hit.point;
            hitVec.y = transform.position.y;

            
            transform.position = Vector3.MoveTowards(transform.position,Vector3.Lerp(transform.position, hitVec, lerpValue), speed * Time.deltaTime);
            Vector3 newMovePoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newMovePoint - transform.position), turnSpeed * Time.deltaTime);
            if (!animator.GetBool("Run"))
            {
                animator.SetBool("Run", true);
            }
        }
        
    }

}
