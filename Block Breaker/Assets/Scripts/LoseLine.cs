using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseLine : MonoBehaviour
{
    LoadScene sceneLoader;
    private void Start() {
        sceneLoader = FindObjectOfType<LoadScene>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        sceneLoader.LoadNextScene();
    }
}
