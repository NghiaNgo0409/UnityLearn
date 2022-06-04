using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieControl : MonoBehaviour
{
    Transform _destination;

    private Quaternion rot;

    public int health;
    
    bool isWalk;

    Animator anim;

    [SerializeField] NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        _destination = PlayerControl.Instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("WalkSpeed", _agent.speed);
        if(_agent.velocity.magnitude > 0)
        {
            isWalk = true;
        }
        else
        {
            isWalk = false;
        }
        anim.SetBool("Walk", isWalk);
        MoveToDestination();
    }

    [ContextMenu("RotateToDestination")]
    void RotateToDestination()
    {
        var targetPos = _destination.position;
        targetPos.y = transform.position.y;

        // Cach 1:
        //Vector3 direction = (targetPos - transform.position).normalized;
        //rot = Quaternion.FromToRotation(transform.forward, direction);
        //transform.rotation = transform.rotation * rot;

        // Cach 2:
        transform.LookAt(targetPos);
    }

    [ContextMenu("Rotate")]
    void Rotate()
    {
        var rot = Quaternion.Euler(0f, 45f, 0f);
        transform.rotation = transform.rotation * rot;
    }

    public void TakeDamage()
    {
        health--;
        Debug.Log(health);
    }

    void MoveToDestination()
    {
        _agent.SetDestination(_destination.position);
    }
}
