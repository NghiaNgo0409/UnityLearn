using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumTest : MonoBehaviour
{
    enum State {Ready, Playing, GameOver};
    // Start is called before the first frame update
    void Start()
    {
        State state = State.Playing;
        print((int)state);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
