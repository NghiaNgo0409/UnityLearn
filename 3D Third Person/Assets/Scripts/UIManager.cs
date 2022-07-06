using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : Singleton<UIManager>
{
    public Text goldText;
    public Text hpText;
    public Text mpText;

    public override void Awake()
    {
        base.Awake();
        instance = this;

        EventManager.Instance.OnGoldChanged += GoldChanged;
        EventManager.Instance.OnHPChanged += HpChanged;
        EventManager.Instance.OnMPChanged += MpChanged;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoldChanged(int value)
    {
        goldText.text = "Gold: " + value;
    }

    void HpChanged(int value)
    {
        hpText.text = "HP: " + value;
    }

    void MpChanged(int value)
    {
        mpText.text = "MP: " + value;
    }
}
