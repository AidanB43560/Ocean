using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] fishPrefabs;
    public int numberOfEnemiesToSpawn = 5;
    public int numberOfFishToSpawn = 10;
    private float spawnZ = 40;
    private float spawnX = 75;
    public int enemyCount;
    public GameObject player;

    void Start(){

        
        for(int i = 0; i < numberOfFishToSpawn; i++){
            //Spawns random fish prefab
            int randomIndex = Random.Range(0, fishPrefabs.Length);
            GameObject randomFishPrefab = fishPrefabs[randomIndex];
            Instantiate(randomFishPrefab, GenerateSpawnPosition(), randomFishPrefab.transform.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
        // respawns enemy when there is none left
        enemyCount = GameObject.FindGameObjectsWithTag("Trash").Length;
        if (enemyCount == 0)
        {
            for (int i = 0; i < numberOfEnemiesToSpawn; i++)
            {

                int randomIndex = Random.Range(0, enemyPrefabs.Length);
                GameObject randomEnemyPrefab = enemyPrefabs[randomIndex];
                Instantiate(randomEnemyPrefab, GenerateSpawnPosition(), randomEnemyPrefab.transform.rotation);
            }
        }
        
    }

    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(spawnX, -spawnX);
        float zPos = Random.Range(spawnZ, -spawnZ);
        return new Vector3(xPos, 0.5f, zPos);
    }
}