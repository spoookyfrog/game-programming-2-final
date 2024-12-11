using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinningrects : MonoBehaviour
{
    public float rotationSpeed = 125f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(eulers:Vector3.forward*rotationSpeed*Time.deltaTime);
    }
}
