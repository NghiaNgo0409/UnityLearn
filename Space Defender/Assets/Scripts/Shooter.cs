using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletLifetime;

    public bool isFiring;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fire()
    {

    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject instance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D instanceRb = instance.GetComponent<Rigidbody2D>();
            instanceRb.velocity = transform.up * bulletSpeed;
            Destroy(instance, bulletLifetime);
        }
    }
}
