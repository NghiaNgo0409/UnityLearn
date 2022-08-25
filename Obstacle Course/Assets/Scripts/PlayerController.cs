using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = Input.GetAxisRaw("Horizontal") * Time.deltaTime * movementSpeed;
        float zValue = Input.GetAxisRaw("Vertical") * Time.deltaTime * movementSpeed;
        transform.Translate(xValue, 0f, zValue);
    }
}
