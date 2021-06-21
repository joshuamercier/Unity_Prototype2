using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Class variables
    private float topBound = 30;
    private float lowerBound = -10;
    private float rightBound = 30;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // If an object goes past the game boundaries, remove that object
        if (transform.position.z > topBound || transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound) // If an anmial has escaped past the player then the game is done
        {
            // Decrease lives then announce lives remaining
            gameManager.AddLives(-1);
            // Destroy this object
            Destroy(gameObject);
            // Check if game over when lives hit 0
            gameManager.CheckGameOver();
        }
    }
}
