using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    Vector2 movementValue;
    Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    void OnMove(InputValue value)
    {
        movementValue = value.Get<Vector2>();
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(movementValue.x, playerRb.velocity.y);
        playerRb.velocity = playerVelocity;
    }
}
