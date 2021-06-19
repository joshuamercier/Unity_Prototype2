using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Class variables
    public GameObject[] animalPrefabs;  // Array of animals

    private float spawnRangeX = 20.0f;  // Range of spawn for X coordiante
    private float spawnRangeZ = 20.0f;  // Range of spawn for Z coordiante
    private float startDelay = 2.0f;    // Seconds of delay for animal spawning to begin
    private float spawnInterval = 1.5f; // Seconds between each animal spawn

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        // Index of animal to spawn
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        // Random vector3 location for animal to be spawned at
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnRangeZ);
        // Creates random animal from the random index, places this animal in the random spawn location, and uses the animal prefab rotation as default
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
