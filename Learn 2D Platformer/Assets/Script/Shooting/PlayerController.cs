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
        }

        void Move()
        {
            float moveValue = horizontalInput * moveSpeed * Time.fixedDeltaTime;
            playerRb.velocity = new Vector2(moveValue, playerRb.velocity.y);
        }

        void UpdateAnimation()
        {
            playerAnim.SetFloat("xVelocity", Mathf.Abs(horizontalInput));
        }
    }

}