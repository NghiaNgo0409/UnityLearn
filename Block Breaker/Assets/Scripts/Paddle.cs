using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthUnit = 16f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePos = Input.mousePosition.x / Screen.width * screenWidthUnit;
        mousePos = Mathf.Clamp(mousePos, minX, maxX);
        Vector2 paddlePos = new Vector2(mousePos, transform.position.y);
        transform.position = paddlePos;
    }
}
