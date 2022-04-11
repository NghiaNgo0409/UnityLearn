using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooting
{
    public class PlayerController : MonoBehaviour
    {
        Rigidbody2D playerRb;
        Animator playerAnim;
        
        float horizontalInput;

        [SerializeField] Transform groundCheckPos;

        [SerializeField] float moveSpeed;
        [SerializeField] float jumpForce;
        [SerializeField] float groundCheckRadius;

        bool isFacingRight = true;
        bool isOnGround;

        [SerializeField] LayerMask groundLayer;
        // Start is called before the first frame update
        void Start()
        {
            playerRb = GetComponent<Rigidbody2D>();
            playerAnim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            GetInput();
            UpdateAnimation();
        }

        void FixedUpdate() 
        {
            Move();
            CheckOnGround();
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
                playerRb.velocity = Vector2.up * jumpForce;
                playerAnim.SetTrigger("isJumping");
            }
        }

        void Flip()
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0, 180, 0);
        }

        void CheckOnGround()
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

        void UpdateAnimation()
        {
            playerAnim.SetFloat("xVelocity", Mathf.Abs(horizontalInput));
        }

        void OnDrawGizmos() 
        {
            Gizmos.DrawWireSphere(groundCheckPos.position, groundCheckRadius);
        }
    }

}