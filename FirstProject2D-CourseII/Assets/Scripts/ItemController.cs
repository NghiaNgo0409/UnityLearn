using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private AudioClip _destroyClip;
    [SerializeField]
    private AudioSource _audio;

    private void OnValidate()
    {
        _audio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"Meet ground: {collision.name}");
        if (collision.gameObject.CompareTag("Ground"))
        {
            _audio.PlayOneShot(_destroyClip);
            Destroy(gameObject, _destroyClip.length);
        }
    }
}
