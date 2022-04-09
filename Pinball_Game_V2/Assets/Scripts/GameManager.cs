using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ball;

    public TMP_Text currentScore;
    public TMP_Text winScore;
    public TMP_Text numBalls;
    public TMP_Text highScoreText;

    public GameObject winPanel;
    public TMP_Text winPanel_scoreText;
    public GameObject losePanel;
    public TMP_Text losePanel_scoreText;

    public int score = 0;
    public int scoreToBeat = 0;
    public int ballCount = 3;
    public int highScore = 0;

    public static GameManager Instance;

    public GameState gameState;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        gameState = GameState.Playing;
        winScore.SetText("Score To Beat: " + scoreToBeat);
        highScoreText.SetText("High Score: " + PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 0));

    }

    void Update()
    {
        if (score >= scoreToBeat && ballCount == 0)
        {
            winPanel_scoreText.SetText("Your Score: " + score + "\n" +
                "Score To Beat: " + scoreToBeat);
            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, highScore);
            }
            winPanel.SetActive(true);
        }
        if (score < scoreToBeat && ballCount == 0)
        {
            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, highScore);
            }
            losePanel_scoreText.SetText("Your Score: " + score + "\n" +
                "Score To Beat: " + scoreToBeat);
            losePanel.SetActive(true);
        }
    }

    public void UpdateGameState(GameState newState)
    {
        switch (newState)
        {
            case GameState.Idle:
                break;
            case GameState.Playing:
                gameState = GameState.Playing;
                HandlePlayingGame();
                break;
            case GameState.WinLevel:
                HandleWinLevel();
                break;
            case GameState.LoseLevel:
                HandleLoseLevel();
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }
    private void HandlePlayingGame()
    {
        Debug.Log("HandlePlayingGame Active!");

        if (ballCount == 0 && score >= scoreToBeat)
        {
            UpdateGameState(GameState.WinLevel);
        }
        if (ballCount == 0)
        {
            UpdateGameState(GameState.LoseLevel);
        }
    }
    private void HandleWinLevel()
    {
        winPanel.SetActive(true);
        Debug.Log("HandleWinLevel Active!");
    }

    private void HandleLoseLevel()
    {
        losePanel.SetActive(true);
        Debug.Log("HandleLoseLevel Active!");

    }

    private void FixedUpdate()
    {
        currentScore.SetText("Score: " + score);

        numBalls.SetText("Balls: " + ballCount);
    }

    public enum GameState
    {
        Idle,
        Playing,
        WinLevel,
        LoseLevel,
        WinGame,
        GameOver
    }
}
