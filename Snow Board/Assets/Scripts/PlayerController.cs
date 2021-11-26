using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SurfaceEffector2D surface2D;
    [SerializeField] float torqueAmount = 10f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    bool canMove = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        surface2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if(canMove)
        {
            RotatePlayer();
            Boostup();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void Boostup()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            surface2D.speed = boostSpeed;
        }
        else
        {
            surface2D.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(-torqueAmount);
        }
    }
}
