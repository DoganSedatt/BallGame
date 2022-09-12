using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;//Düþman objesi
    public GameObject powerUpObject;
    public int enemyCount;
    public int vaveNumber;//Dalga sayýsý arttýkça doðacak düþman sayýsý da artacak.
    private float spawnRange = 9;//Aralýk
    void Start()
    {
        SpawnEnemy(vaveNumber);
        Instantiate(powerUpObject, RandomSpawnPos(), powerUpObject.transform.rotation);
        
    }
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;//içerisinde enemy scripti barýndýran objelerin sayýsýný tutacak.
        if (enemyCount == 0)//Eðer düþman sayýsý 0'a eþitse;
        {
            
            vaveNumber++;
            SpawnEnemy(vaveNumber);//Belirtilen miktarda düþman oluþtur.
            Instantiate(powerUpObject, RandomSpawnPos(), powerUpObject.transform.rotation);

        }
    }
    private Vector3 RandomSpawnPos()//Düþman doðuþ pozisyonunu rastgele belirler
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);//-9 ile 9 arasýnda X kordinat deðeri
        float spawnZ = Random.Range(-spawnRange, spawnRange);//-9 ile 9 arasýnda Z kordinat deðeri
        Vector3 randomPos = new Vector3(spawnX, 0, spawnZ);//Oluþacak olan bu rastgele pozisyon deðerini Vector3 deðiþkeninde tuttuk.
        return randomPos;//Ve onu kullanabilmek için return ettik. Instantiate metodunun içinde çaðýrdýk
    }
    void SpawnEnemy(int totalEnemy)
    {
        for (int i = 0; i < totalEnemy; i++)
        {
            Instantiate(enemy, RandomSpawnPos(), enemy.transform.rotation);
            //Düþman objesini, RandomSpawnPos metodundan gelen kordinatlarda üret. 
        }
    }
    
}
