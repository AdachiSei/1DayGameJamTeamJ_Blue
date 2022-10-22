using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : SingletonMonoBehaviour<LightManager>
{
    public event Action LightOn;
    public event Action LightOff;

    protected override void Awake()
    {
        base.Awake();
        LightOn();
    }

    public void OnLight()
    {
        LightOn();
    }
    public void OffLight()
    {
        LightOff();
    }
}
