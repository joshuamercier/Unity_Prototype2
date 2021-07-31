using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Class variables
    public bool isGameOver;
    public bool isGamePaused;
    public bool isGameStarted;

    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private int gameScore = 0;
    [SerializeField] private int gameLives = 3;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI scoreGameOverText;
    [SerializeField] private GameObject spawnManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isGameStarted)
        {
            ChangePause();
        }
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
        if (gameLives > 0)
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
            isGameOver = true;
            GameOver();
        }
    }

    public void GameOver()
    {
        /// Disable game UI
        gameUI.SetActive(false);
        // Enable the Game Over screen
        gameOverScreen.SetActive(true);
        // Set score text
        SetGameOverScoreText();
    }

    private void ChangePause()
    {
        if (!isGamePaused)
        {
            isGamePaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            isGamePaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        // Disable the title screen when starting the game
        titleScreen.gameObject.SetActive(false);
        spawnManager.SetActive(true);
        UpdateLives();
        UpdateScore();
        isGameStarted = true;
    }

    private void SetGameOverScoreText()
    {
        string text = "You acheived a total score of " + gameScore + ",";
        if(gameScore <= 10)
        {
            text += " you should try harder next time!";
        }
        else if(gameScore > 10 && gameScore <= 50)
        {
            text += " not bad at all!";
        }
        else if(gameScore > 50 && gameScore <= 200)
        {
            text += " wow very impressive!";
        }
        else
        {
            text += " wow that is a god-level score!";
        }
        scoreGameOverText.text = text;
    }
}
