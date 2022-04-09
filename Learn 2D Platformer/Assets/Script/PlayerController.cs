using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;

    float horizontalInput;

    [SerializeField] float moveSpeed;
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
}
