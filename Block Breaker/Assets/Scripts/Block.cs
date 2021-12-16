using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Play play;
    [SerializeField] AudioClip breakSound;
    private void Start() {
        play = FindObjectOfType<Play>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
