using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    Rigidbody2D bulletsRb;
    [SerializeField] float bulletsSpeed;
    [SerializeField] GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        bulletsRb = GetComponent<Rigidbody2D>();
        bulletsRb.velocity = transform.right * bulletsSpeed;
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        other.gameObject.GetComponent<Enemy>().TakeDamage(40);
        Destroy(gameObject);
    }
}
