using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Class variables
    private float horizontalInput;
    private float verticalInput;

    public float speed = 10.0f;
    public float xRange = 20.0f; // Boundary of player X-axis
    public float zUpperRange = 18.0f; // boundary of player upper Z-axis
    public float zLowerRange = -3.5f; // boundary of player lower Z-axis
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
        // Keep player in upper boundary
        if(transform.position.z > zUpperRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zUpperRange);
        }
        // Keep player in lower boundary
        if (transform.position.z < zLowerRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zLowerRange);
        }

        // Check that player is throwing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch food projectile
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
    }
}
