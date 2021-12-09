using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] TextSO startingState;
    TextSO currentState;
    TextSO[] nextStates;
    // Start is called before the first frame update
    void Start()
    {
        currentState = startingState;
        text.text = currentState.GetText();
        nextStates = startingState.GetNextStates();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentState = nextStates[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentState = nextStates[1];
        }
        else if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            currentState = startingState;
        }
        text.text = currentState.GetText();
    }
}
