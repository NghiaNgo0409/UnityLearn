using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 delta = rawInput;
        transform.position += delta;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
}
