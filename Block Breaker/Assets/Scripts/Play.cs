using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    [SerializeField] int breakableBlocks;
    LoadScene sceneLoader;

    private void Start() {
        sceneLoader = FindObjectOfType<LoadScene>();
    }

    public void CountBreakableBlock()
    {
        breakableBlocks++;
    }

    public void DestroyBlocks()
    {
        breakableBlocks--;
        if(breakableBlocks == 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
