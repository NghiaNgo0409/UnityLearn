using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITakeDamageable
{
    void TakeDamage(DamageObject damgObj, int damage);
}
