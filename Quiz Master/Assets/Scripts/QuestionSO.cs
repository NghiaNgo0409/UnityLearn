using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(minLines: 2, maxLines: 6)]
    [SerializeField]string question = "Text a question here";
    [SerializeField]string[] answer = new string[4];
    public string GetQuestion()
    {
        return question;
    }
}
