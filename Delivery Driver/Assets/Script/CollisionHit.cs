using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Hit!");   
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Package")
        {
            Debug.Log("Package picked up!");
        }    
    }
}
