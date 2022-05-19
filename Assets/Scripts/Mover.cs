using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    float inputHorizontal,inputVertical;
    public float speed;
    void Start()
    {
        
    }


    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(inputHorizontal,0,inputVertical) * Time.deltaTime*speed);
    }
}
