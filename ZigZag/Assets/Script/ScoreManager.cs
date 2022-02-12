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
        InvokeRepeating("IncrementScore", .1f, .5f);
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
}
