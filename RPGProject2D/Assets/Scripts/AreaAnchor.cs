using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaAnchor : MonoBehaviour
{
    [SerializeField] string areaName;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerController.instance.areaTransitionName == areaName)
        {
            PlayerController.instance.transform.position = transform.position;
            UIFade.instance.FadeFromBlack();
            GameManager.instance.isLoadingScreen = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
