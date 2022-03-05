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
    bool isFacingLeft = true;
    
    [Header("Check Ground")]
    [SerializeField] Transform groundCheckPos;
    [SerializeField] float groundRadius;
    [SerializeField] LayerMask groundLayer;
    [Header("Attack")]
    [SerializeField] BoxCollider2D hitBox;
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
    }

    private void FixedUpdate() {
    }

    void GetInput()
    {
        if(Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            state = PlayerState.Jump;
            playerAnim.SetTrigger("Jump");
            playerAnim.SetBool("Run", false);
            playerRb.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
            return;
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if(isFacingLeft)
            { 
                Flip();
            }
            playerAnim.SetBool("Run", true);
            state = PlayerState.Run;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if(!isFacingLeft)
            {
                Flip();
            }
            playerAnim.SetBool("Run", true);
            state = PlayerState.Run;
        }
        else if(Input.GetButtonDown("Fire1"))
        {
            state = PlayerState.Attack;
            playerAnim.SetTrigger("Attack");
            hitBox.enabled = true;
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
    }
    void Flip()
    {
        isFacingLeft = !isFacingLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
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
        hitBox.enabled = false;
    }
}
