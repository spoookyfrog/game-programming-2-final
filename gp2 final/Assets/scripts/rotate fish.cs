using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatefish : MonoBehaviour
{
    public float rotationSpeed = 125f;
   
    void Update()
    {
        transform.Rotate(eulers:Vector3.up*rotationSpeed*Time.deltaTime);
    }
}
