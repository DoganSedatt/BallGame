using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;//Düþman objesi
    private float spawnRange = 9;//Aralýk
    void Start()
    {
        Instantiate(enemy, RandomSpawnPos(), enemy.transform.rotation);
        //Düþman objesini, RandomSpawnPos metodundan gelen kordinatlarda üret. 
    }
    private Vector3 RandomSpawnPos()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);//-9 ile 9 arasýnda X kordinat deðeri
        float spawnZ = Random.Range(-spawnRange, spawnRange);//-9 ile 9 arasýnda Z kordinat deðeri
        Vector3 randomPos = new Vector3(spawnX, 0, spawnZ);//Oluþacak olan bu rastgele pozisyon deðerini Vector3 deðiþkeninde tuttuk.
        return randomPos;//Ve onu kullanabilmek için return ettik. Instantiate metodunun içinde çaðýrdýk
    }
}
