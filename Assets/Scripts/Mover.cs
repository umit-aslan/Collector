using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Camera cam;
    public Animator animator;
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
            animator.SetBool("Idling", false);
            Movement();
        }
        else
        {
            if (animator.GetBool("Run"))
            {
                animator.SetBool("Run", false);
                animator.SetBool("Idling", true);
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
            if (!animator.GetBool("Run"))//Eğer run animasyonu çalışmıyorsa
            {
                animator.SetBool("Run", true);//Run animasyonu çalıştırılıyor.
            }
        }
        
    }

}
