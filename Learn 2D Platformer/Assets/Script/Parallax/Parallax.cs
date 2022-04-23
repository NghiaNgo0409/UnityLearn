using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    float length, startPos;
    [SerializeField] GameObject cam;
    [SerializeField] float parallaxValue;
    [SerializeField] float offSet = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = cam.transform.position.x * (1 - parallaxValue);
        float distance = cam.transform.position.x * parallaxValue;

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
        
        if(temp > startPos + length - offSet) startPos += length;
        else if (temp < startPos - length + offSet) startPos -= length;
    }
}
