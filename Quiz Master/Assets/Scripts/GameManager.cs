using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndScreen endScreen;

    void Awake() 
    {
        quiz = FindObjectOfType<Quiz>();
        endScreen = FindObjectOfType<EndScreen>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
