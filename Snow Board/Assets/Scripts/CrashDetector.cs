using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    float delayTime = 1.0f;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Ground")
        {
            Invoke("ReloadScene", delayTime);
        }    
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
