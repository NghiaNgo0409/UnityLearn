using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    Rigidbody2D playerRb;
    Animator playerAnim;

    public string areaTransitionName;

    Vector3 bottomLeft;
    Vector3 topRight;

    public bool canMove = true;
    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        DontDestroyOnLoad(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            playerRb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * 6f;
        }
        else
        {
            playerRb.velocity = new Vector2(0f, 0f);
        }

        playerAnim.SetFloat("speedX", playerRb.velocity.x);
        playerAnim.SetFloat("speedY", playerRb.velocity.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            if(canMove)
            {
                playerAnim.SetFloat("lastPosX", Input.GetAxisRaw("Horizontal"));
                playerAnim.SetFloat("lastPosY", Input.GetAxisRaw("Vertical"));
            }
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeft.x, topRight.x), Mathf.Clamp(transform.position.y, bottomLeft.y, topRight.y), transform.position.z);
    }

    public void SetBound(Vector3 bot, Vector3 top)
    {
        bottomLeft = bot + new Vector3(0.5f, 0.5f, 0f);
        topRight = top + new Vector3(-0.5f, -0.5f, 0f);
    }
}
