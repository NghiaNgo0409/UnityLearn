using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingControl : MonoBehaviour
{
    [SerializeField] AudioMixer settingAudio;
    [SerializeField] Slider sliderUI;
    float volume;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        volume = sliderUI.value;
        settingAudio.SetFloat("VolumeMainMenu", volume);
    }
}
