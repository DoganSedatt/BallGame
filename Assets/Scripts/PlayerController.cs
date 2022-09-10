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
        odakNoktasi = GameObject.Find("OdakNoktasý");//Odak noktasý oyun objesi sahnede aranýp deðiþkene atýldý.
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");//Dikey girdiyi tutan deðiþken
        rb.AddForce(odakNoktasi.transform.forward*speed*forwardInput);
        //Player objemin rigidbodysine kuvvet ekliyorum.Ancak uygulanan bu kuvvet player objemin baktýðý yöne doðru deðil,odak noktasý objemin baktýðý yöne doðru ekleniyor.
    }
}
