using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;
    Animator playerAnim;

    float horizontalInput;
    
    int availableJumps;

    [SerializeField] Collider2D ceilingCollider;
    [SerializeField] Transform groundCheckPos;
    [SerializeField] Transform wallCheckPos;
    [SerializeField] Transform ceilingCheckPos;

    [SerializeField] float moveSpeed;
    [SerializeField] float crouchSpeedRate;
    [SerializeField] float jumpForce;
    [SerializeField] float slideSpeed;
    [SerializeField] float groundCheckRadius;
    [SerializeField] float wallCheckRadius;
    [SerializeField] float ceilingCheckRadius;

    [SerializeField] int totalJumps = 2;
    
    bool isOnGround;
    bool isTouchingWall;
    bool isTouchingCeiling;
    bool isCrouching;
    bool isSliding;
    bool isFacingRight = true;
    bool isCoyoteJump;
    bool isMultipleJump;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask wallLayer;
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
        CheckTouchingWall();
        Crouch();
        UpdateAnimations();
    }

    void FixedUpdate() 
    {
        CheckOnGround();
        CheckTouchingCeiling();
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

        //Crouch
        if(Input.GetKey(KeyCode.C))
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }
    }

    void Move()
    {
        float moveValue = horizontalInput * moveSpeed * Time.fixedDeltaTime;
        if(!ceilingCollider.enabled)
        {
            playerRb.velocity = new Vector2(moveValue * crouchSpeedRate, playerRb.velocity.y);
        }
        else
        {
            playerRb.velocity = new Vector2(moveValue, playerRb.velocity.y);
        }
    }

    void Jump()
    {
        if(isOnGround)
        {
            isMultipleJump = true;
            availableJumps--;
            playerRb.velocity = Vector2.up * jumpForce;
        }
        else
        {
            if(isCoyoteJump)
            {
                playerRb.velocity = Vector2.up * jumpForce;
            }
            if(isMultipleJump && availableJumps > 0)
            {
                availableJumps--;
                playerRb.velocity = Vector2.up * jumpForce;
            }
        }
    }

    void Crouch()
    {
        if(isOnGround)
        {
            ceilingCollider.enabled = !isCrouching;
        }
        
        if(!isCrouching)
        {
            ceilingCollider.enabled = !isTouchingCeiling;
        }
    }

    IEnumerator CoyoteJump()
    {
        isCoyoteJump = true;
        yield return new WaitForSeconds(0.2f);
        isCoyoteJump = false;
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180f, 0);
    }

    void CheckOnGround()
    {
        bool wasGrounded = isOnGround;
        var hitGround = Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, groundLayer);

        if(hitGround)
        {
            isOnGround = true;
            if(!wasGrounded)
            {
                availableJumps = totalJumps;
                isMultipleJump = false;
            }
        }
        else
        {
            isOnGround = false;
            if(wasGrounded)
            {
                StartCoroutine(CoyoteJump());
            }
        }
    }

    void CheckTouchingWall()
    {
        var hitWall = Physics2D.OverlapCircle(wallCheckPos.position, wallCheckRadius, wallLayer);
        
        if(hitWall && Mathf.Abs(horizontalInput) > 0 &&!isOnGround && playerRb.velocity.y < 0)
        {
            isTouchingWall = true;
            if(!isSliding)
            {
                availableJumps = totalJumps;
                isMultipleJump = false;
            }
            playerRb.velocity = new Vector2(playerRb.velocity.x, -slideSpeed);
            isSliding = true;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                isMultipleJump = true;
                availableJumps--;
                playerRb.velocity = Vector2.up * jumpForce;
            }
        }
        else
        {
            isTouchingWall = false;
            isSliding = false;
        }
    }

    void CheckTouchingCeiling()
    {
        var hitCeiling = Physics2D.OverlapCircle(ceilingCheckPos.position, ceilingCheckRadius, groundLayer);

        if(hitCeiling)
        {
            isTouchingCeiling = true;
        }
        else
        {
            isTouchingCeiling = false;
        }
    }

    void UpdateAnimations()
    {
        playerAnim.SetFloat("xVelocity", Mathf.Abs(horizontalInput));
        playerAnim.SetFloat("yVelocity", playerRb.velocity.y);
        playerAnim.SetBool("isOnGround", isOnGround);
        playerAnim.SetBool("isCrouching", !ceilingCollider.enabled);
    }
    
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(groundCheckPos.position, groundCheckRadius);
        Gizmos.DrawWireSphere(wallCheckPos.position, wallCheckRadius);
        Gizmos.DrawWireSphere(ceilingCheckPos.position, ceilingCheckRadius);
    }
}
