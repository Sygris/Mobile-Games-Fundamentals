using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject FallingBlockPrefab;
    public float SecondsBetweenSpawn = 1f;
    float NextSpawnTime;

    public Vector2 SpawnMinMaxSize;
    public float SpawnAngleMax;

    Vector2 HalfScreenSizeWorldUnits;


    void Start()
    {
        HalfScreenSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    void Update()
    {
        if (Time.time > NextSpawnTime)
        {
            NextSpawnTime = Time.time + SecondsBetweenSpawn;

            float SpawnAngle = Random.Range(-SpawnAngleMax, SpawnAngleMax);
            float SpawnSize = Random.Range(SpawnMinMaxSize.x, SpawnMinMaxSize.y);
            
            Vector2 SpawnPosition = new Vector2(Random.Range(-HalfScreenSizeWorldUnits.x, HalfScreenSizeWorldUnits.x), HalfScreenSizeWorldUnits.y + SpawnSize/2f);
            GameObject NewBlock = Instantiate(FallingBlockPrefab, SpawnPosition, Quaternion.Euler(Vector3.forward * SpawnAngle));

            NewBlock.transform.localScale = Vector2.one * SpawnSize;
        }

    }
}
