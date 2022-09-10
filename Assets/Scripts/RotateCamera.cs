using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;//D�n�� h�z�

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");//Yatay girdiyi tutan de�i�ken
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        //Objeyi d�nder=Vector3.up, rotate metodunda sa�� ve solu ifade eder.
    }
}
