using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;
    Animator playerAnim;

    float horizontalInput;
    
    int availableJumps;

    [SerializeField] Transform groundCheckPos;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float groundCheckRadius;

    [SerializeField] int totalJumps = 2;
    
    bool isOnGround;
    bool isFacingRight = true;

    [SerializeField] LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        availableJumps = totalJumps;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        UpdateAnimations();
    }

    void FixedUpdate() 
    {
        CheckCollision();
        Move();    
    }

    void GetInput()
    {
        //Move
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if(horizontalInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if(horizontalInput < 0 && isFacingRight)
        {
            Flip();
        }

        //Jump
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Move()
    {
        float moveValue = horizontalInput * moveSpeed * Time.fixedDeltaTime;
        playerRb.velocity = new Vector2(moveValue, playerRb.velocity.y);
    }

    void Jump()
    {
        if(isOnGround)
        {
            availableJumps--;
            playerRb.velocity = Vector2.up * jumpForce;
        }
        else
        {
            if(availableJumps > 0)
            {
                availableJumps--;
                playerRb.velocity = Vector2.up * jumpForce;
            }
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180f, 0);
    }

    void CheckCollision()
    {
        var hitGround = Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, groundLayer);

        if(hitGround)
        {
            isOnGround = true;
            availableJumps = totalJumps;
        }
        else
        {
            isOnGround = false;
        }
    }

    void UpdateAnimations()
    {
        playerAnim.SetFloat("xVelocity", Mathf.Abs(horizontalInput));
        playerAnim.SetFloat("yVelocity", playerRb.velocity.y);
        playerAnim.SetBool("isOnGround", isOnGround);
    }
    
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(groundCheckPos.position, groundCheckRadius);
    }
}
