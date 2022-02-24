using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject gameMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            if(gameMenu.activeInHierarchy)
            {
                GameManager.instance.isGameMenuActive = false;
                gameMenu.SetActive(false);
            }
            else
            {
                GameManager.instance.isGameMenuActive = true;
                gameMenu.SetActive(true);
            }
        }
    }
}
