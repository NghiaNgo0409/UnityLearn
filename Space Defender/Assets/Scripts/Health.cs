using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] bool isPlayer;
    [SerializeField] ParticleSystem hitEffect;
    AudioPlayer audioPlayer;
    ScoreKeeper ScoreKeeper;
    void Awake() 
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();    
        ScoreKeeper = FindObjectOfType<ScoreKeeper>();
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
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        ScoreKeeper.ModifyScore(score);
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
