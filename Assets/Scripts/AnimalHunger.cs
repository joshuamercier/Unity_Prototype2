using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    // Class variables
    public Slider hungerSlider;
    public int amountToBeFed;

    private int currentFedAmount = 0;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        // Set slider to amount to be fed
        hungerSlider.maxValue = amountToBeFed;
        // set slider value to zero
        hungerSlider.value = 0;
        hungerSlider.fillRect.gameObject.SetActive(false);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to feed the animal
    public void FeedAnimal(int amount)
    {
        currentFedAmount += amount;
        hungerSlider.fillRect.gameObject.SetActive(true);
        hungerSlider.value = currentFedAmount;
        if (currentFedAmount >= amountToBeFed)
        {
            gameManager.AddScore(amountToBeFed);
            Destroy(gameObject, 0.1f);
        }
    }
}
