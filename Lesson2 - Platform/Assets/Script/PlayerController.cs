using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;
    Animator playerAnim;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] SpriteRenderer playerSprite;
    [SerializeField] PlayerState state;
    
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
        state = PlayerState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == PlayerState.Attack) return;
        GetInput();
        CheckOnGround();
        Jump();
    }

    private void FixedUpdate() {
    }

    void GetInput()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            playerSprite.flipX = true;
            playerAnim.SetBool("Run", true);
            state = PlayerState.Run;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            playerSprite.flipX = false;
            playerAnim.SetBool("Run", true);
            state = PlayerState.Run;
        }
        else if(Input.GetButtonDown("Fire1"))
        {
            state = PlayerState.Attack;
            playerAnim.SetTrigger("Attack");
        }
        else
        {
            if(state != PlayerState.Idle)
            {
                state = PlayerState.Idle;
                playerAnim.SetTrigger("Idle");
                playerAnim.SetBool("Run", false);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            state = PlayerState.Jump;
            playerAnim.SetTrigger("Jump");
        }
    }
  
    void Jump()
    {
        if(state == PlayerState.Jump && onGround)
        {
            playerRb.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
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
        }
        playerAnim.SetBool("isGround", onGround);
    }

    public enum PlayerState
    {
        None = 0, Idle = 1, Run = 2, Attack = 3, Jump = 4, Dead = 5
    }

    public void Attack01_End()
    {
        state = PlayerState.Idle;
        playerAnim.SetTrigger("Idle");
    }
}
