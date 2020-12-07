using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public List<Transform> SpawnTransfroms;
    
    public GameObject FallingBlockPrefab;
    
    public float SecondsBetweenSpawn = 1f;
    float NextSpawnTime;

    void Start()
    {
        
    }

    void Update()
    {
        int RandomIndex = Random.Range(0, SpawnTransfroms.Count);

        if (Time.time > NextSpawnTime)
        {
            NextSpawnTime = Time.time + SecondsBetweenSpawn;

            Instantiate(FallingBlockPrefab, SpawnTransfroms[RandomIndex].position, Quaternion.identity);
        }
    }
}
