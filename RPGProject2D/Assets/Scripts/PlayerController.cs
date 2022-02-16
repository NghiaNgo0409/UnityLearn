using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;
    Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * 6f;

        playerAnim.SetFloat("speedX", playerRb.velocity.x);
        playerAnim.SetFloat("speedY", playerRb.velocity.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            playerAnim.SetFloat("lastPosX", Input.GetAxisRaw("Horizontal"));
            playerAnim.SetFloat("lastPosY", Input.GetAxisRaw("Vertical"));
        }
    }
}
