using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;  // Dog object
    public float fireRate = 0.5f; // Fire rate to launch dog

    private bool canFire = true;  // Flag for player to launch dog

    // Update is called once per frame
    void Update()
    {
        // On spacebar press and player can fire, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canFire)
        {
            StartCoroutine("LaunchDog");
        }
    }

    // Coroutine for launching the dog, waits on fire rate before allowing another dog to be launched
    IEnumerator LaunchDog()
    {
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
