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
}
