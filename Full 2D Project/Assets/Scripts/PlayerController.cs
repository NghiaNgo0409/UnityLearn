using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerController : MonoBehaviour, ITakeDamageable
{
    [SerializeField] Animator _anim;
    [SerializeField] SpriteRenderer _render;
    [SerializeField] PlayerState _state;
    [SerializeField] float _rayLength;
    [SerializeField] Transform _checkGround;
    [SerializeField] Rigidbody2D _rigid2D;
    [SerializeField] float _jumpForce;
    [SerializeField] DamageObject _damgObj;
    [SerializeField] float _knockbackForce;

    [SerializeField] int _hp;
    private int AttackCombo;
    public float _speed;

    [SerializeField] private bool _isOnGround;
    private bool _isFlip;

    [SerializeField] private float _attackTime = 0.5f;
    private float _time;

    [SerializeField] float _lockDamgTime = 1f;
    private float _damgTime;
    private bool _isLockDamg;
    
    // Start is called before the first frame update
    void Start()
    {
        _state = PlayerState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isLockDamg)
        {
            _damgTime += Time.deltaTime;
            if (_damgTime >= _lockDamgTime)
            {
                _damgTime = 0;
                _isLockDamg = false;
            }
        }

        CheckOnGround();

        if (_state == PlayerState.Attack) return;
        if (_state == PlayerState.Hurt) return;
        if (_state == PlayerState.Jump && _isOnGround && _rigid2D.velocity.y > 0f)
        {
            _isOnGround = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            _state = PlayerState.Jump;
            _anim.SetTrigger("jump");
            _rigid2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            _state = PlayerState.Attack;
            _anim.SetTrigger("attack");
            //AttackAsync();
            //_hitBox.enabled = true;
            //_time = _attackTime;
            return;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _state = PlayerState.Run;
            if (_isOnGround)
                _rigid2D.velocity = Vector2.zero;
            //_render.flipX = false;
            if (_isFlip)
                Flip();
            _anim.SetBool("run", true);
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _state = PlayerState.Run;
            if (_isOnGround)
                _rigid2D.velocity = Vector2.zero;
            //_render.flipX = true;
            if (!_isFlip)
                Flip();
            _anim.SetBool("run", true);
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }
        else
        {
            if (_state == PlayerState.Jump && !_isOnGround) return;
            if (_state != PlayerState.Idle)
            {
                _state = PlayerState.Idle;
                _rigid2D.velocity = Vector2.zero;
                _anim.SetBool("run", false);
                _anim.SetTrigger("idle");
            }
        }
    }

    public void Handle_Event_EndHurt()
    {
        Debug.Log("EndHurt");
        _state = PlayerState.None;
    }

    public void TakeDamage(DamageObject damgObj, int damg)
    {
        if (_isLockDamg) return;
        Debug.Log("<color=yellow>Player take damage</color>");
        _hp -= damg;
        _isLockDamg = true;
        _state = PlayerState.Hurt;
        _anim.SetTrigger("Hurt");

        var direction = (transform.position - damgObj.transform.position).normalized;
        direction.y = 0f;
        _rigid2D.AddForce(direction * _knockbackForce, ForceMode2D.Impulse);
        //WaitForLockDamgAsync();
    }

    //async void WaitForLockDamgAsync()
    //{
    //    await Task.Delay((int)_lockDamgTime * 1000);
    //    _isLockDamg = false;
    //}

    private void Flip()
    {
        _isFlip = !_isFlip;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    //private async void AttackAsync()
    //{
    //    _hitBox.enabled = true;
    //    await Task.Delay(100);
    //    _hitBox.enabled = false;
    //}

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
    private void FixedUpdate()
    {
        //Debug.Log($"FixedUpdate: {Time.fixedDeltaTime}");
        //if (_state == PlayerState.Jump && _isOnGround)
        //{
        //    _rigid2D.AddForce(Vector2.up * _jumpForce);
        //}
    }

    private void CheckOnGround()
    {
        Debug.DrawRay(_checkGround.position, Vector2.down * _rayLength, Color.red);
        var hit = Physics2D.Raycast(_checkGround.position, Vector2.down, _rayLength);
        // Ngắn hơn.
        _isOnGround = hit.collider && hit.collider.CompareTag("Ground");

        _anim.SetBool("isGround", _isOnGround);
    }

    public void OnAttack_01_End(int value)
    {
        //Debug.Log("OnAttack_01_End");
        _state = PlayerState.Idle;
        _anim.SetTrigger("idle");
        AttackCombo = value;
        _anim.SetInteger("AttackCombo", AttackCombo);
    }

    public void OnAttack_01()
    {
        _damgObj.Attack();
    }

    [ContextMenu("Test_Force")]
    private void Test_Force()
    {
        _rigid2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);
    }

    [ContextMenu("Test_ForceImpulse")]
    private void Test_ForceImpulse()
    {
        _rigid2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}

public enum PlayerState
{
    None = 0,
    Idle = 1,
    Run = 2,
    Attack = 3,
    Jump = 4,
    Dead = 5,
    Hurt = 6,
}
