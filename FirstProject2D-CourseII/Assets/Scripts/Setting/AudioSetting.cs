using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private AudioMixerGroup _audioGroup;
    [SerializeField]
    private string _paramName;
    [SerializeField]
    private float _volumn;

    public float Volumn 
    { 
        get => _volumn;
        set
        {
            _volumn = value;
            _audioGroup.audioMixer.SetFloat(_paramName, Volumn);
            PlayerPrefs.SetFloat(_paramName, _volumn);
        }
    }

    public string ParamName => _paramName;

    private void OnValidate()
    {
        _slider = GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _slider.value = PlayerPrefs.GetFloat(_paramName);
    }

    private void Update()
    {
        Volumn = _slider.value;
    }

    public void Setup(float value)
    {
        _audioGroup.audioMixer.SetFloat(_paramName, value);
    }
}
