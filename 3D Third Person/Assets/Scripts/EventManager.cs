using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : Singleton<EventManager>
{
    public Action<int> OnGoldChanged;
    public Action<int> OnHPChanged;
    public Action<int> OnMPChanged;
    public override void Awake()
    {
        base.Awake();
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
