using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;//Dönüþ hýzý

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");//Yatay girdiyi tutan deðiþken
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        //Objeyi dönder=Vector3.up, rotate metodunda saðý ve solu ifade eder.
    }
}
