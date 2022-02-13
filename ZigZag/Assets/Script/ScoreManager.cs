using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    int score;

    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(score);
    }

    void IncrementScore()
    {
        score++;
    }

    public void AddScore(int val)
    {
        score += val;
    }

    public void StartScore()
    {
        InvokeRepeating("IncrementScore", .1f, .5f);
    }

    public void StopScore()
    {
        CancelInvoke("IncrementScore");
        PlayerPrefs.SetInt("score", score);

        if(PlayerPrefs.HasKey("highscore"))
        {
            if(PlayerPrefs.GetInt("highscore") < score)
            {
                PlayerPrefs.SetInt("highscore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
