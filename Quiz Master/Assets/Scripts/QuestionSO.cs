using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionSO : ScriptableObject
{
    [SerializeField]string question = "Text a question here";

    public string GetQuestion()
    {
        return question;
    }
}
