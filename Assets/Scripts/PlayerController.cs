using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5.0f;
    private GameObject odakNoktasi;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        odakNoktasi = GameObject.Find("OdakNoktas�");//Odak noktas� oyun objesi sahnede aran�p de�i�kene at�ld�.
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");//Dikey girdiyi tutan de�i�ken
        rb.AddForce(odakNoktasi.transform.forward*speed*forwardInput);
        //Player objemin rigidbodysine kuvvet ekliyorum.Ancak uygulanan bu kuvvet player objemin bakt��� y�ne do�ru de�il,odak noktas� objemin bakt��� y�ne do�ru ekleniyor.
    }
}
