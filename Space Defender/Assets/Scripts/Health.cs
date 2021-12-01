using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;

    void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damage = other.GetComponent<DamageDealer>();
        if(damage != null)
        {
            TakeDamage(damage.GetDamage());
            damage.Hit();
        }    
    }
}
