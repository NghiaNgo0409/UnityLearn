using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletLifetime;
    [SerializeField] float baseFiringRate;
    [SerializeField] float firingRateVariance;
    [SerializeField] float minFiringRate;
    [SerializeField] bool useAI;
    [HideInInspector]public bool isFiring;

    AudioPlayer audioPlayer;

    Coroutine fireCoroutine;
    void Awake() 
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();    
    }
    // Start is called before the first frame update
    void Start()
    {
        if(useAI)
        {
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject instance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D instanceRb = instance.GetComponent<Rigidbody2D>();
            instanceRb.velocity = transform.up * bulletSpeed;
            Destroy(instance, bulletLifetime);
            float timeFiringRate = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
            timeFiringRate = Mathf.Clamp(timeFiringRate, minFiringRate, float.MaxValue);
            if(useAI)
            {
                yield return new WaitForSeconds(timeFiringRate);
            }
            else
            {
                yield return new WaitForSeconds(baseFiringRate);
            }
        }
    }
}
