using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform ballPos;
    Vector3 offset;
    [SerializeField] float lerpRate;
    // Start is called before the first frame update
    void Start()
    {
        offset = ballPos.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPos = ballPos.position - offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, lerpRate * Time.deltaTime);
    }
}
