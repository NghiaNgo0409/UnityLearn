using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    [SerializeField] PlayerWeaponControl _playerWeaponCtrl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadSet()
    {
        _playerWeaponCtrl.isReloading = false;
    }

}
