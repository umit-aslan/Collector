using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public Vector3  offset;
    public float lerpValue;
    void LateUpdate()
    {
        Vector3 desPos = target.position + offset;//Hedefin pozisyonu + offset'i al.
        transform.position = Vector3.Lerp(transform.position, desPos, lerpValue);//Hedefin pozisyonu ile transform'in pozisyonunu lerp'le.
    }
}
