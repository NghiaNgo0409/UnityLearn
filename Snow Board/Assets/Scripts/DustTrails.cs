using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrails : MonoBehaviour
{
    [SerializeField] ParticleSystem dustParticles;

    void OnCollisionEnter2D(Collision2D other) 
    {
        dustParticles.Play();    
    }
    void OnCollisionExit2D(Collision2D other) 
    {
        dustParticles.Stop();    
    }
}
