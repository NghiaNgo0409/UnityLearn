using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    Rigidbody platformRb;
    // Start is called before the first frame update
    void Awake()
    {
        platformRb = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Ball")
        {
            PlatformFalling();
        }    
    }

    void PlatformFalling()
    {
       platformRb.useGravity = true;
       platformRb.isKinematic = false;

       Destroy(gameObject, 2f);
    }
}
