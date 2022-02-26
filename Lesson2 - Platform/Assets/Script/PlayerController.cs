using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;
    Animator playerAnim;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    bool isJump;
    bool isFacingRight = false;
    PlayerState playerState;
    
    [Header("Check Ground")]
    [SerializeField] Transform groundCheckPos;
    [SerializeField] float groundRadius;
    [SerializeField] LayerMask groundLayer;
    bool onGround;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerState = PlayerState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        if(Input.GetAxisRaw("Horizontal") > 0 && !isFacingRight)
        {
            playerState = PlayerState.Run;
            Flip();
        }
        else if(Input.GetAxisRaw("Horizontal") < 0 && isFacingRight)
        {
            playerState = PlayerState.Run;
            Flip();
        }
        else
        {
            if(playerState != PlayerState.Idle)
            {
                playerState = PlayerState.Idle;
                playerAnim.SetTrigger("Idle");
            }
        }
        if(Input.GetButtonDown("Fire1"))
        {
            playerState = PlayerState.Attack;
            playerAnim.SetTrigger("Attack");
        }
    }

    private void FixedUpdate() {
        CheckOnGround();
        Jump();
    }

    void GetInput()
    {
        //Move
        playerRb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, playerRb.velocity.y);
        playerAnim.SetFloat("xVelocity", playerRb.velocity.x);
        //Jump
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
        }
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        isFacingRight = !isFacingRight;
    }
    
    void Jump()
    {
        if(isJump && onGround)
        {
            playerRb.velocity += new Vector2(0f, jumpForce * Time.deltaTime);
            isJump = false;
        }
    }

    void CheckOnGround()
    {
        if(Physics2D.OverlapCircleAll(groundCheckPos.position, groundRadius, groundLayer).Length > 0)
        {
            onGround = true;
        }
        else
        {
            onGround = false;
            isJump = false;
        }
    }

    public enum PlayerState
    {
        None = 0, Idle = 1, Run = 2, Attack = 3, Jump = 4, Dead = 5
    }

    public void Attack01_End()
    {
        playerState = PlayerState.Idle;
        playerAnim.SetTrigger("Idle");
    }
}
