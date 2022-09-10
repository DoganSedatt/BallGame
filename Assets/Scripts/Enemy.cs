using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    public float speed;
    private GameObject player;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;//Player ile aradaki mesafeyi buluyor
        //Normalized,nesnenin h�z�n� korumak i�in ekleniyor.Aksi takdirde iki y�nl� harekette(x,y gibi) olmas� gerekenden daha h�zl� hareket edecekti.
        enemyRb.AddForce(lookDirection*speed);
    }
}
