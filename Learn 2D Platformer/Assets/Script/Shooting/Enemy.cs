using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator enemyAnim;
    int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        enemyAnim.SetTrigger("Die");
        Destroy(gameObject, 0.3f);
    }
}
