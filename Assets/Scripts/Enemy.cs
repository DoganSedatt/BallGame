using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    private float enemyDeathPosition = -5f;//Düþmanýn düþtükten sonra yok olacaðý konum deðeri
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
        enemyRb.AddForce(lookDirection*speed);//Düþmana kuvvet ekle(x,y,z sine kuvvet ekliyor. O deðerleri de player ile arasýndaki mesafeden alýyor*speed)

        if (transform.position.y < enemyDeathPosition)
        {//Eðer düþmanýn konumu ölüm posizyon deðerinden küçükse(Platformdan aþaðýya düþmüþse);

            Destroy(this.gameObject);//Bu objeyi yok et
        }
    }
}
