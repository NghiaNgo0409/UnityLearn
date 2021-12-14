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
        
    }
}
