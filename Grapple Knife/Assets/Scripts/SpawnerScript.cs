using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject spawnedObject;
    public float spawnRadius = 20f;
    public int maxSpawnObj = 10;
    private int spawnCounter = 0;

 

    private void FixedUpdate()
    {
        if (spawnCounter < maxSpawnObj)
        {
            SpawnObjectAtRandom();
        }
        Debug.Log("No. of Obj's at: " + spawnCounter);
    }

    void SpawnObjectAtRandom()
    {
        // randomPos = new Vector3(randomPos.x, 0, randomPox.Y);
        
         Vector3 randomPos = Random.insideUnitSphere * spawnRadius;

        Instantiate(spawnedObject, randomPos, Quaternion.identity);
        spawnCounter++;

    }
}
