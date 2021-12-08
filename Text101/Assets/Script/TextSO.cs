using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "textSave")]
public class TextSO : ScriptableObject
{
    [TextArea(10, 14)][SerializeField] string text;
    [SerializeField] TextSO[] nextState;

    public string GetText()
    {
        return text;
    }

    public TextSO[] GetNextStates()
    {
        return nextState;
    }
}
