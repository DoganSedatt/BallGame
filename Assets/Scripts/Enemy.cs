using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    private float enemyDeathPosition = -5f;//D��man�n d��t�kten sonra yok olaca�� konum de�eri
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
        enemyRb.AddForce(lookDirection*speed);//D��mana kuvvet ekle(x,y,z sine kuvvet ekliyor. O de�erleri de player ile aras�ndaki mesafeden al�yor*speed)

        if (transform.position.y < enemyDeathPosition)
        {//E�er d��man�n konumu �l�m posizyon de�erinden k���kse(Platformdan a�a��ya d��m��se);

            Destroy(this.gameObject);//Bu objeyi yok et
        }
    }
}
