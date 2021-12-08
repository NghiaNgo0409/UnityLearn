using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "textSave")]
public class TextSO : ScriptableObject
{
    [TextArea(10, 14)][SerializeField] string text;

    public string GetText()
    {
        return text;
    }
}
