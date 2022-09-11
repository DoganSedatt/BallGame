using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject odakNoktasi;
    private float powerUpStrength = 15.0f;//�tme g�c�

    public float speed = 5.0f;
    public GameObject powerActiveObject;
    public bool hasPowerUp;//G��lendirmenin etkin olup olmad���n� kontrol edecek.
    
    Rigidbody enemyRb;//D��man rigidbodysine ula�mak i�in.
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
        powerActiveObject.transform.position = transform.position + new Vector3(0, -0.4f, 0);
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerup"))
        {
            powerActiveObject.gameObject.SetActive(true);
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerDownCoroutine());//Ekstra g�� olay�n� zamanla kald�ran metodu �a��ran metod;
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("enemy")&& hasPowerUp)
        {
            enemyRb = collision.gameObject.GetComponent<Rigidbody>();//D��man rigidbodysi de�i�kene at�ld�. Art�k buna kuvvet uygulayabiliriz
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            //awayFromPlayer=�arp�lan nesne(Enemy) ile �arpan nesne(Player) aras�ndaki mesafeyi Vector3 cinsinden tutuyor. Bu de�er ayn� zamanda force de�erimiz olacak.
            Debug.Log("�arp�lan nesne:" + collision.gameObject.name + "G��lendirme aktif mi:" + hasPowerUp);
            Debug.Log(awayFromPlayer);
            enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            //D��man rb'sine kuvvet ekle=Player ile aradaki mesafe*powerUpStrength,Forcemode ise Impulse(�tki anlam�nda).
        }
    }
    IEnumerator PowerDownCoroutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerUp = false;
        powerActiveObject.gameObject.SetActive(false);
    }
}
