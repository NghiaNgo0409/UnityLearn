using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    Score score;
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<Score>();
    }

    public void ShowFinalScore()
    {
        finalScoreText.text = "Congratulations!\nYou scored " + score.CalculateScore() + "%";
    }
}
