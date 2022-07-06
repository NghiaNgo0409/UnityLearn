using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    Animator playerAnimator;
    Rigidbody rb;
    public float upJumpSpeed = 5;
    public float forwardJumpSpeed = 1;

    private int gold;
    private int health;
    private int mana;

    public UnityEvent OnDead = new UnityEvent();

    public int Gold 
    { 
        get => gold; 
        set 
        {
            gold = value;
            EventManager.Instance.OnGoldChanged?.Invoke(gold);
        }
    }
    public int Health 
    { 
        get => health; 
        set
        {
            health = value;
            EventManager.Instance.OnHPChanged?.Invoke(health);
            if(health <= 0)
            {
                OnDead?.Invoke();
            }
        }
    }

    public int Mana 
    {
        get => mana; 
        set
        {
            mana = value;
            EventManager.Instance.OnMPChanged?.Invoke(mana);
        }
    }

    // Use this for initialization
    void Awake () {
        playerAnimator = GetComponent<Animator>();
        playerAnimator.applyRootMotion = true;
        rb = GetComponent<Rigidbody>();
        
    }

    private void Start() {
        Gold = 1000;
        Health = 100;
        Mana = 100;
    }

    // Update is called once per frame
    void FixedUpdate () {
        var v = Input.GetAxis("Vertical");
        var h = Input.GetAxis("Horizontal");


        playerAnimator.SetFloat("forwardSpeed", v);
        playerAnimator.SetFloat("turnSpeed", h);

        // if (Input.GetButtonDown("Duck"))
        // {
        //     playerAnimator.SetTrigger("duck");
        // }

        // if (Input.GetButtonDown("Jump"))
        // {
        //     playerAnimator.SetTrigger("jump");
        //     rb.velocity += Vector3.up * upJumpSpeed + transform.forward * forwardJumpSpeed;
        // }

        bool grounded = Mathf.Abs(Vector3.Dot(rb.velocity, Vector3.up)) < 0.01;
        // playerAnimator.applyRootMotion = grounded;
        playerAnimator.SetBool("grounded", grounded);
    }

    [ContextMenu("IncreaseGold")]
    public void IncreaseGold()
    {
        Gold++;
    }

    [ContextMenu("IncreaseMP")]
    public void IncreaseMana()
    {
        Mana++;
    }

    [ContextMenu("Die")]
    public void Die()
    {
        Health = 0;
    }
}
