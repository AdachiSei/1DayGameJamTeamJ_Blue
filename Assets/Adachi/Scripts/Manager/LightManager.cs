using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : SingletonMonoBehaviour<LightManager>
{
    public event Action LightOn;
    public event Action LightOff;

    [SerializeField]
    [Header("�����肪���Ă�w�i")]
    SpriteRenderer _lightOn;

    [SerializeField]
    [Header("�����肪�����Ă�w�i")]
    SpriteRenderer _lightOff;

    protected override void Awake()
    {
        base.Awake();
        _lightOff.gameObject.SetActive(false);
    }

    public void OnLight()
    {
        _lightOn.gameObject.SetActive(true);
        _lightOff.gameObject.SetActive(false);
        LightOn();
    }

    public void OffLight()
    {
        _lightOn.gameObject.SetActive(false);
        _lightOff.gameObject.SetActive(true);
        LightOff();
    }
}
