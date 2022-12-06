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

    public void SetupBox()
    {
        //choose random spawn point
        //check if spawn point was already used before
        //spawn obj at new spawn point
        //clear tracker of spawn points
        int randomBox = Random.Range(0, boxObjs.Length);
        int randomSpawn = Random.Range(0, spawnPoints.Length);

        Instantiate(boxObjs[randomBox], spawnPoints[randomSpawn].transform.position, Quaternion.identity);

        Debug.Log("Spawned obj" + randomBox + "at spawnPoint no." + randomSpawn);
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
