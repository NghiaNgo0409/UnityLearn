using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] TextSO startingState;
    TextSO currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = startingState;
        text.text = currentState.GetText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
