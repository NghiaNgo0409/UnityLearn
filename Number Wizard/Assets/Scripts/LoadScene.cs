using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] int currentSceen;

    void Start()
    {
        currentSceen = SceneManager.GetActiveScene().buildIndex;
    }
}
