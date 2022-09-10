using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;//D��man objesi
    private float spawnRange = 9;//Aral�k
    void Start()
    {
        Instantiate(enemy, RandomSpawnPos(), enemy.transform.rotation);
        //D��man objesini, RandomSpawnPos metodundan gelen kordinatlarda �ret. 
    }
    private Vector3 RandomSpawnPos()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);//-9 ile 9 aras�nda X kordinat de�eri
        float spawnZ = Random.Range(-spawnRange, spawnRange);//-9 ile 9 aras�nda Z kordinat de�eri
        Vector3 randomPos = new Vector3(spawnX, 0, spawnZ);//Olu�acak olan bu rastgele pozisyon de�erini Vector3 de�i�keninde tuttuk.
        return randomPos;//Ve onu kullanabilmek i�in return ettik. Instantiate metodunun i�inde �a��rd�k
    }
}
