using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVector : MonoBehaviour
{
    public Transform a;
    public Transform b;
    public float speed;
    public float range;
    public bool isTargetInside;

    public float dotValue;
    public Vector3 crossValue;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 ab = b.position - a.position;
        var distance = ab.magnitude;
        var distance2 = Vector2.Distance(b.position, a.position);
        Debug.Log($"distance = {distance} distance2 = {distance2}");

        //transform.position = a.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Direction with normalized.
        //var direction = b.position - a.position;
        //transform.Translate(direction.normalized * speed * Time.deltaTime);

        // Using sqrmagnitude to calculate range.
        //var direction = transform.position - b.position;
        //if (direction.sqrMagnitude < Mathf.Pow(range, 2))
        //    isTargetInside = true;
        //else
        //    isTargetInside = false;

        // Using dot product.
        Debug.DrawLine(a.position, b.position, Color.red);
        Debug.DrawRay(transform.position, transform.right, Color.cyan);
        var direction1 = transform.right;
        var direction2 = (b.position - a.position).normalized;
        dotValue = Vector2.Dot(direction1, direction2);
        crossValue = Vector3.Cross(direction1, direction2);
    }
}
