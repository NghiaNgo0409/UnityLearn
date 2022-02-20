using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Square : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _txtSpeed;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private SpeedSetting _configData;

    // Start is called before the first frame update
    void Start()
    {
        _speed = _configData.Speed;
        _txtSpeed.SetText($"Current Speed: {_speed} \n ConfigSpeed: {_configData.Speed}");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }
    }

    public void OnBtnSpeedUpClicked()
    {
        _speed += 1;
        _configData.Speed += 1;

        _txtSpeed.SetText($"Current Speed: {_speed} \n ConfigSpeed: {_configData.Speed}");
    }
}
