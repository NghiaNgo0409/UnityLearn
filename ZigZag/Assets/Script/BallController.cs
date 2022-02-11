using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody ballRb;
    [SerializeField] float speed;
    bool started;
    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ballRb.velocity);
        if(!started)
        {
            if(Input.GetMouseButtonDown(0))
            {
                ballRb.velocity = new Vector3(speed, 0, 0);
                started = true;
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            SwitchDirection();
        }
        
        if(!Physics.Raycast(transform.position, Vector3.down, Mathf.Infinity))
        {
            ballRb.velocity = new Vector3(0, -speed, 0);
        }
    }

    void SwitchDirection()
    {
        if(ballRb.velocity.z > 0)
        {
            ballRb.velocity = new Vector3(speed, 0, 0);
        }
        else if(ballRb.velocity.x > 0)
        {
            ballRb.velocity = new Vector3(0, 0, speed);
        }
    }
}
