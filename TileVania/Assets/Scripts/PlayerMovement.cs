using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    Vector2 movementValue;
    Rigidbody2D playerRb;

    Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Flip();
    }

    void OnMove(InputValue value)
    {
        movementValue = value.Get<Vector2>();
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(movementValue.x * runSpeed, playerRb.velocity.y);
        playerRb.velocity = playerVelocity;

        bool hasRun = Mathf.Abs(playerRb.velocity.x) > Mathf.Epsilon;
    }
    
    void Flip()
    {
        bool hasRun = Mathf.Abs(playerRb.velocity.x) > Mathf.Epsilon;
        if(hasRun)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRb.velocity.x), 1f);
        }
    }
}
