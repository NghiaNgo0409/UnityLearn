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

        [SerializeField] float moveSpeed;

        bool isFacingRight = true;
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
        }

        void GetInput()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            if(horizontalInput > 0 && !isFacingRight)
            {
                Flip();
            }
            else if(horizontalInput < 0 && isFacingRight)
            {
                Flip();
            }
        }

        void Move()
        {
            float moveValue = horizontalInput * moveSpeed * Time.fixedDeltaTime;
            playerRb.velocity = new Vector2(moveValue, playerRb.velocity.y);
        }

        void Flip()
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0, 180, 0);
        }

        void UpdateAnimation()
        {
            playerAnim.SetFloat("xVelocity", Mathf.Abs(horizontalInput));
        }
    }

}