using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponControl : MonoBehaviour
{
    [SerializeField] Camera _cam;
    [SerializeField] LayerMask _targetMask;
    [SerializeField] int _fireRate;
    [SerializeField] int _ammo;
    [SerializeField] Animator _playerAnim;
    [SerializeField] UICanvasPlayer canvas;
    float _nextShootingTime;
    public bool isReloading;
    // Start is called before the first frame update
    void Start()
    {
        _nextShootingTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && Time.time > _nextShootingTime)
        {
            _nextShootingTime = Time.time + 1.0f / _fireRate;
            ShootFromCamera();
            _playerAnim.SetTrigger("Fire");
            canvas.ExpandCrossHair();
            _ammo--;
        }

        if(Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            isReloading = true;
            Reload();
        }
    }

    void ShootFromCamera()
    {
        Ray ray = new Ray(_cam.transform.position, _cam.transform.forward);
        RaycastHit hit = new RaycastHit();
        bool isHit = Physics.Raycast(ray, out hit, 200f, _targetMask);
        if(isHit)
        {
            hit.collider.GetComponent<ZombieControl>().TakeDamage();
        }

        Debug.DrawRay(_cam.transform.position, _cam.transform.forward * 200f, Color.blue);
    }

    void Reload()
    {
        _playerAnim.SetTrigger("Reload");
    }

    
}
