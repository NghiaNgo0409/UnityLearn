using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCorrectAnswer;
    [SerializeField] float timeToShowAnswer;

    float timeValue;

    public float fillFraction;
    public bool isAnsweringQuestion;
    public bool loadNextQuestion;

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateAnswer()
    {
        timeValue -= Time.deltaTime;
        if(isAnsweringQuestion)
        {
            if(timeValue > 0)
            {
                fillFraction = timeValue/timeToCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion = false;
                timeValue = timeToShowAnswer;
            }
        }
        else
        {
            if(timeValue > 0)
            {
                fillFraction = timeValue/timeToShowAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                timeValue = timeToCorrectAnswer;
                loadNextQuestion = true;
            }
        }
    }
}
