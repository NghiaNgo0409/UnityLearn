using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector2 distancePaddleToBall;
    [SerializeField] Paddle paddle;
    // Start is called before the first frame update
    void Start()
    {
        distancePaddleToBall = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        LockBallToPaddle();
        LaunchGame();
    }

    void LaunchGame()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f,15f);
        }
    }

    void LockBallToPaddle()
    {
        transform.position = (Vector2)paddle.transform.position + distancePaddleToBall;
    }
}
