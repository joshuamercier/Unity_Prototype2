using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Class variables
    private float topBound = 30;
    private float lowerBound = -5;
    private float rightBound = 25;
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
        if(transform.position.z > topBound)
        {
            // Instead of destroying simply set inactive
            gameObject.SetActive(false);
        }
        else if (transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound) // If an animal has escaped past the player then decrease score
        {
            // Decrease score then update UI to reflect
            gameManager.AddScore(-5);
            // Destroy this object
            Destroy(gameObject);
            // Check if game over when lives hit 0
            gameManager.CheckGameOver();
        }
    }
}
