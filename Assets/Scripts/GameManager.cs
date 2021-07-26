using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Class variables
    public bool isGameOver;

    [SerializeField] private int gameScore = 0;
    [SerializeField] private int gameLives = 3;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;

    private void Start()
    {
        UpdateLives();
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + gameScore;
    }

    private void UpdateLives()
    {
        livesText.text = "Lives: " + gameLives;
    }

    // Method for adding/decreasing score
    public void AddScore(int amount)
    {
        // Check that player has not already finished the game
        if(gameLives > 0)
        {
            gameScore += amount;
            UpdateScore();
        }

    }

    // Method for adding/decreasing lives
    public void AddLives(int amount)
    {
        gameLives += amount;
        // Check that player has not already finished the game
        if (gameLives >= 0)
        {
            UpdateLives();
        }
    }

    public void CheckGameOver()
    {
        if (gameLives == 0)
        {
            Debug.Log("Game Over!");
            isGameOver = true;
        }
    }
}
