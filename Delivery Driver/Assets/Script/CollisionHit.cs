using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHit : MonoBehaviour
{

    bool hasPackage;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Hit!");   
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Package")
        {
            Debug.Log("Package picked up!");
            hasPackage = true;
        }
        if(other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package is delivered to customer!");
            hasPackage = false;
        }    
    }
}
