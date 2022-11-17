using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBouncerSpawnManager : MonoBehaviour
{
    
    public GameObject enemyPrefab; // set preference to prefab
    public GameObject powerUpPrefab;

    private float spawnRange = 4.5f; // spawnRange

    public int enemyCount;
    public int powerUpCount;

    public int waveNumber = 1;
    public int powerWaveNumer = 1;
    
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerUpWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {       
        enemyCount = FindObjectsOfType<BallBouncerEnemy>().Length;

        if(enemyCount == 0)
        { 
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerUpWave(waveNumber);
        }
        
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);           
        }
    }

    void SpawnPowerUpWave(int powerUpToSpawn)
    {
        for (int i = 0; i < powerUpToSpawn; i++)
        {
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        }
    }




    private Vector3 GenerateSpawnPosition()
    {
        // randomaize position
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }    
}
