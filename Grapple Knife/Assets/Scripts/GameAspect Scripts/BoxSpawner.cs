using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [Header("Vars")]
    [SerializeField] float respawnDelay;

    [Header("Obj Refs")]
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] GameObject[] boxObjs;
    [SerializeField] ScoreManager sm;

    [Header("Resetting values")]
    int randomBox;
    int randomSpawn;
    int lastPnt;

    //recurisve function to make sure spawn point is diff every time
    int randomSpawnPoint()
    {
        int randPnt = Random.Range(0, spawnPoints.Length);
        while (lastPnt == randPnt)
        {
            randPnt = Random.Range(0, spawnPoints.Length);
        }
        return randPnt;
    }

    public void SetupBox()
    {  
        if (sm.playerScore <= 0)
        {
            randomBox = Random.Range(0, boxObjs.Length);
            randomSpawn = Random.Range(0, spawnPoints.Length);

            Instantiate(boxObjs[randomBox], spawnPoints[randomSpawn].transform.position, Quaternion.identity);
        }
        else
        {
            randomBox = Random.Range(0, boxObjs.Length);
            int spawnPnt = randomSpawnPoint();

            Instantiate(boxObjs[randomBox], spawnPoints[spawnPnt].transform.position, Quaternion.identity);
            lastPnt = spawnPnt;
        }
    }

    public IEnumerator SpawnBox(float delay)
    {
        yield return new WaitForSeconds(delay);
        SetupBox();
    }

    public void BoxKilled()
    {
        StartCoroutine(SpawnBox(respawnDelay));
    }
}
