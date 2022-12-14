using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : SingletonMonoBehaviour<LightManager>
{
    public event Action LightOn;
    public event Action LightOff;

    [SerializeField]
    [Header("明かりがついてる背景")]
    SpriteRenderer _lightOn;

    [SerializeField]
    [Header("明かりが消えてる背景")]
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
        SoundManager.Instance.PlaySFX(SFXType.LightOnOff);
        LightOn();
    }

    public void OffLight()
    {
        _lightOn.gameObject.SetActive(false);
        _lightOff.gameObject.SetActive(true);
        SoundManager.Instance.PlaySFX(SFXType.LightOnOff);
        LightOff();
    }
}
