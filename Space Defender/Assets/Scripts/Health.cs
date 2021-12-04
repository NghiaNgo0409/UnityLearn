using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    AudioPlayer audioPlayer;
    void Awake() 
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();    
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damage = other.GetComponent<DamageDealer>();
        if(damage != null)
        {
            TakeDamage(damage.GetDamage());
            audioPlayer.PlayDamageClip();
            PlayHitEffect();
            damage.Hit();
        }    
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public int GetHealth()
    {
        return health;
    }

    void PlayHitEffect()
    {
        ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(instance, instance.main.duration + instance.main.startLifetime.constantMax);
    }
}
