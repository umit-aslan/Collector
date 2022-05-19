using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
     //float inputHorizontal,inputVertical;
    // public float speed;
    Animator animator;
    Vector3 firstPos,endPos;
    public float playerSpeed;
    public float xMin,Xmax;

    void Start() {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
       /*
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(inputHorizontal,0,inputVertical) * Time.deltaTime*speed);
        animator.SetBool("Idling",true);
        if (inputVertical!=0||inputHorizontal!=0)
        {
            animator.SetBool("Idling",false);
            animator.SetBool("Run",true);
        }
        else
        {
            animator.SetBool("Run",false);
            animator.SetBool("Idling",true);
        }
         */

        if (Input.GetMouseButtonDown(0))
        {
            firstPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            endPos = Input.mousePosition;
            float distanceX = endPos.x - firstPos.x;
            float distanceZ = endPos.z - firstPos.z;
            transform.Translate(new Vector3(distanceX,distanceZ,0) * Time.deltaTime * playerSpeed/100);
            animator.SetBool("Idling",false);
            animator.SetBool("Run",true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            firstPos = Vector3.zero;
            endPos = Vector3.zero;
            animator.SetBool("Run",false);
            animator.SetBool("Idling",true);
        }
    }

}
