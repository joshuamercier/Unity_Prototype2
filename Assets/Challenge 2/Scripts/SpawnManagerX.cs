using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    //public float spawnInterval = 4.0f;
    private float minSpawnTime = 3.0f;
    private float maxSpawnTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomBall", startDelay);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Create random index to generate a random ball color
        int ballIndex = Random.Range(0, ballPrefabs.Length);
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
        Debug.Log(Time.time); // Log check when ball was created

        // Call the next ball spawn in a random time interval of the given range
        Invoke("SpawnRandomBall", SpawnInterval());
    }

    float SpawnInterval()
    {
        return Random.Range(minSpawnTime, maxSpawnTime);
    }

}
