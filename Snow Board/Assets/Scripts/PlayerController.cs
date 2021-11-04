using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float torqueAmount = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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
