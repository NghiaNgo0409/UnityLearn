using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed;
    [SerializeField] float climbSpeed;
    float gravityScaleAtStart;
    Vector2 movementValue;
    Rigidbody2D playerRb;
    CapsuleCollider2D playerCapsuleCollider;
    Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerCapsuleCollider = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = playerRb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Flip();
        ClimbLadder();
    }

    void OnMove(InputValue value)
    {
        movementValue = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if(!playerCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;
        if(value.isPressed)
        {
            playerRb.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(movementValue.x * runSpeed, playerRb.velocity.y);
        playerRb.velocity = playerVelocity;

        bool hasRun = Mathf.Abs(playerRb.velocity.x) > Mathf.Epsilon;
        playerAnim.SetBool("isRunning", hasRun);
    }
    
    void Flip()
    {
        bool hasRun = Mathf.Abs(playerRb.velocity.x) > Mathf.Epsilon;
        if(hasRun)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRb.velocity.x), 1f);
        }
    }

    void ClimbLadder()
    {
        if(!playerCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            playerRb.gravityScale = gravityScaleAtStart;
            return;
        }
        Vector2 climbVelocity = new Vector2(playerRb.velocity.x, movementValue.y * climbSpeed);
        playerRb.velocity = climbVelocity;
        playerRb.gravityScale = 0;
    }
}
