using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameSession : MonoBehaviour
{
    int playerScore;
    [SerializeField] int playerLives;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if(numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start() 
    {
        livesText.text = playerLives.ToString();
        playerScore = 0;
    }

    void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void ProcessGameSession()
    {
        if(playerLives > 1)
        {
            TakesLive();
        }
        else
        {
            ResetLevel();
        }
    }

    void TakesLive()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
    }

    void ResetLevel()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
