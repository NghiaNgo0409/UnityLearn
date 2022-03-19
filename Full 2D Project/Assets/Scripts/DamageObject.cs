using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    [SerializeField] BoxCollider2D _hitBox;
    [SerializeField] LayerMask _mask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        var cols = Physics2D.OverlapBoxAll(_hitBox.transform.position,
            _hitBox.size * transform.localScale.x, 0f, _mask);
        foreach (var col in cols)
        {
            col.GetComponent<ITakeDamageable>()?.TakeDamage(this, 1);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_hitBox.transform.position, _hitBox.size * transform.parent.localScale.x);
    }
}
