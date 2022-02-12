using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] ParticleSystem diamondParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Ball")
        {
            Instantiate(diamondParticles, transform.position, Quaternion.identity);
            ScoreManager.instance.AddScore(5);
            Destroy(gameObject);
        }
    }
}
