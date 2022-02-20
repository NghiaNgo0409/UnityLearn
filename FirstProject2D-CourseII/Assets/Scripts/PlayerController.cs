using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Slider _sliderHp;

    [SerializeField]
    private Spawner _spawner;
    [SerializeField]
    private CanvasController _canvasCtrl;
    [SerializeField]
    private AudioSource _audio;
    [SerializeField]
    private AudioClip _damageSound;
    [SerializeField]
    private AudioClip _itemSound;

    [SerializeField]
    private SpriteRenderer _spriteRender;
    [SerializeField]
    private Animator _anim;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private int _lives;
    [SerializeField]
    private int _score;
    [SerializeField]
    private bool _isDead;

    public int Lives
    {
        get => _lives;
        set
        {
            _lives = value;
            _isDead = _lives <= 0;
            if (_isDead)
            {
                _anim.SetTrigger("triggerDead");
                _canvasCtrl.ShowReplayUI();
                Time.timeScale = 0f;    // Pause game.
            }
            _sliderHp.value = _lives;
            _canvasCtrl.SetLives(_lives);
        }
    }

    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            _canvasCtrl.SetScore(_score);
            PlayerPrefs.SetInt("score", _score);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //_anim.SetFloat("", 5.5f);
        //_anim.SetInteger("", 5);
        //_anim.SetTrigger("");
        _anim.SetBool("isLeft", false);
        _anim.SetBool("isIdle", true);

        _sliderHp.minValue = 0;
        _sliderHp.maxValue = Lives;
        _canvasCtrl.SetLives(Lives);
        _canvasCtrl.SetScore(Score);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log("User press right key!");
            // Cách 1:
            //transform.position += new Vector3(_speed, 0f, 0f) * Time.deltaTime;
            // Cách 2:
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
            //_spriteRender.flipX = false;
            _anim.SetBool("isLeft", false);
            _anim.SetBool("isIdle", false);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("User press left key!");
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
            //_spriteRender.flipX = true;
            _anim.SetBool("isLeft", true);
            _anim.SetBool("isIdle", false);
        }
        else
        {
            _anim.SetBool("isIdle", true);
        }
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"OnTriggerEnter2D: {collision.gameObject}");

        if (collision.gameObject.CompareTag("ItemFruit"))  // Nếu ăn phải trái cây thì + score.
        {
            Score += 10;
            _audio.PlayOneShot(_itemSound);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("ItemPoison")) // Nếu ăn phải chất độc thì - lives.
        {
            Lives -= 1;
            _audio.PlayOneShot(_damageSound);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("ItemTrigger"))
        {
            _spawner.Spawn();
        }
    }

    [ContextMenu("Test_DeadState")]
    private void Test_DeadState()
    {
        Debug.Log("Test_DeadState");
        Lives -= Lives;
    }

    [ContextMenu("Test_AddScore1000")]
    private void Test_AddScore1000()
    {
        Debug.Log("Test_AddScore1000");
        Score += 1000;
    }
}
