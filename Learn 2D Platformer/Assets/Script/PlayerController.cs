using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;

    float horizontalInput;

    [SerializeField] Transform groundCheckPos;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float groundCheckRadius;
    
    bool isOnGround;
    bool isFacingRight = true;

    [SerializeField] LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
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
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
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
        playerRb.velocity = Vector2.up * jumpForce;
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
        }
        else
        {
            isOnGround = false;
        }
    }
    
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(groundCheckPos.position, groundCheckRadius);
    }
}
