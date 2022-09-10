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
        //Normalized,nesnenin hýzýný korumak için ekleniyor.Aksi takdirde iki yönlü harekette(x,y gibi) olmasý gerekenden daha hýzlý hareket edecekti.
        enemyRb.AddForce(lookDirection*speed);
    }
}
