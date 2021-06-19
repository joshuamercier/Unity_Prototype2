using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Class variables
    private float horizontalInput;

    public float speed = 10.0f;
    public float xRange = 20.0f; // Boundary of player X-axis
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Keep player in left boundary
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        // Keep player in right boundary
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Check that player is throwing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch food projectile
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }
}
