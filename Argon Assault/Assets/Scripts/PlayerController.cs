using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float xRange;
    [SerializeField] float yRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float xRawPos = (xInput * Time.deltaTime * moveSpeed) + transform.localPosition.x;
        float xNewPos = Mathf.Clamp(xRawPos, -xRange, xRange);

        float yInput = Input.GetAxis("Vertical");
        float yRawPos = (yInput * Time.deltaTime * moveSpeed) + transform.localPosition.y;
        float yNewPos = Mathf.Clamp(yRawPos, -yRange, yRange);

        transform.localPosition = new Vector3(xNewPos, yNewPos, transform.localPosition.z);
    }
}
