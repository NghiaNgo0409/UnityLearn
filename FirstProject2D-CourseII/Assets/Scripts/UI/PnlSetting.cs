using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnlSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnBtnExitClicked()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
