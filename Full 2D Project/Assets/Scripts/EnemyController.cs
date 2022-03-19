using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, ITakeDamageable
{
    [SerializeField] private int _hp = 3;
    [SerializeField] DamageObject _damgObj;
    [SerializeField] float _attackCooldown = 1f;
    [SerializeField] float _movementSpeed;
    [SerializeField] Animator _anim;

    float _atkTime;
    Vector3 _moveDirection;
    [SerializeField] EnemyState _state;

    // Start is called before the first frame update
    void Start()
    {
        //_state = EnemyState.Idle;
        _state = EnemyState.Run;
        _moveDirection = Vector2.left;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStates();
        UpdateAttack();
    }

    private void UpdateAttack()
    {
        if (_state == EnemyState.Hurt) return;
        _atkTime += Time.deltaTime;
        if (_atkTime >= _attackCooldown)
        {
            _damgObj.Attack();
            _atkTime = 0f;
        }
    }

    private void Move()
    {
        transform.Translate(_moveDirection * _movementSpeed * Time.deltaTime);
    }

    private void UpdateStates()
    {
        switch (_state)
        {
            case EnemyState.None:
                //_anim.SetBool("isRun", false);
                _state = EnemyState.Run;
                _anim.SetBool("isHurt", false);
                break;
            case EnemyState.Idle:
                _anim.SetBool("isRun", false);
                _anim.SetBool("isHurt", false);
                break;
            case EnemyState.Run:
                _anim.SetBool("isRun", true);
                _anim.SetBool("isHurt", false);
                Move();
                break;
            case EnemyState.Hurt:
                _anim.SetBool("isHurt", true);
                break;
            default:
                break;
        }
    }

    public void Handle_Event_EndHurt()
    {
        Debug.Log("<color=green>End enemy hurt.</color>");
        _state = EnemyState.None;
    }

    public void TakeDamage(DamageObject damgObj, int damg)
    {
        Debug.Log("TakeDamg");
        _hp -= damg;
        _state = EnemyState.Hurt;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            _moveDirection = (transform.position - collision.collider.transform.position).normalized;
            _moveDirection.y = 0f;
            if (_moveDirection.x < 0f)
            {
                _moveDirection = Vector2.left;
                var scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
            else
            {
                _moveDirection = Vector2.right;
                var scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }
    }

    public enum EnemyState
    {
        None,
        Idle,
        Run,
        Hurt,
    }
}
