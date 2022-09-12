using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;//D��man objesi
    public GameObject powerUpObject;
    public int enemyCount;
    public int vaveNumber;//Dalga say�s� artt�k�a do�acak d��man say�s� da artacak.
    private float spawnRange = 9;//Aral�k
    void Start()
    {
        SpawnEnemy(vaveNumber);
        Instantiate(powerUpObject, RandomSpawnPos(), powerUpObject.transform.rotation);
        
    }
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;//i�erisinde enemy scripti bar�nd�ran objelerin say�s�n� tutacak.
        if (enemyCount == 0)//E�er d��man say�s� 0'a e�itse;
        {
            
            vaveNumber++;
            SpawnEnemy(vaveNumber);//Belirtilen miktarda d��man olu�tur.
            Instantiate(powerUpObject, RandomSpawnPos(), powerUpObject.transform.rotation);

        }
    }
    private Vector3 RandomSpawnPos()//D��man do�u� pozisyonunu rastgele belirler
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);//-9 ile 9 aras�nda X kordinat de�eri
        float spawnZ = Random.Range(-spawnRange, spawnRange);//-9 ile 9 aras�nda Z kordinat de�eri
        Vector3 randomPos = new Vector3(spawnX, 0, spawnZ);//Olu�acak olan bu rastgele pozisyon de�erini Vector3 de�i�keninde tuttuk.
        return randomPos;//Ve onu kullanabilmek i�in return ettik. Instantiate metodunun i�inde �a��rd�k
    }
    void SpawnEnemy(int totalEnemy)
    {
        for (int i = 0; i < totalEnemy; i++)
        {
            Instantiate(enemy, RandomSpawnPos(), enemy.transform.rotation);
            //D��man objesini, RandomSpawnPos metodundan gelen kordinatlarda �ret. 
        }
    }
    
}
