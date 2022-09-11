using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5.0f;
    private GameObject odakNoktasi;
    public bool hasPowerUp;//Güçlendirmenin etkin olup olmadýðýný kontrol edecek.
    private float powerUpStrength = 15.0f;//Ýtme gücü
    Rigidbody enemyRb;//Düþman rigidbodysine ulaþmak için.
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerup"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("enemy")&& hasPowerUp)
        {
            enemyRb = collision.gameObject.GetComponent<Rigidbody>();//Düþman rigidbodysi deðiþkene atýldý. Artýk buna kuvvet uygulayabiliriz
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            //awayFromPlayer=Çarpýlan nesne(Enemy) ile çarpan nesne(Player) arasýndaki mesafeyi Vector3 cinsinden tutuyor. Bu deðer ayný zamanda force deðerimiz olacak.
            Debug.Log("Çarpýlan nesne:" + collision.gameObject.name + "Güçlendirme aktif mi:" + hasPowerUp);
            Debug.Log(awayFromPlayer);
            enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            //Düþman rb'sine kuvvet ekle=Player ile aradaki mesafe*powerUpStrength,Forcemode ise Impulse(Ýtki anlamýnda).
        }
    }
}
