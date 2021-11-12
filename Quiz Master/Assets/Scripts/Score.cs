using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int correctAnswer = 0;
    int questionSeen = 0;

    public int GetCorrectAnswer()
    {
        return correctAnswer;
    }

    public int GetQuestionSeen()
    {
        return questionSeen;
    }

    public void IncremenCorrectAnswer()
    {
        correctAnswer++;
    }

    public void IncrementQuestionSeen()
    {
        questionSeen++;
    }
}
