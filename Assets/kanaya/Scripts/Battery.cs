using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    PlayerController _playerCon;

    [SerializeField]
    [Header("�o�b�e���[�c��")]
    Slider _batterySlider;

    void Start()
    {
        _batterySlider.maxValue = _playerCon.MaxBattery;
        _batterySlider.value = _playerCon.NowBattery;
    }
    public void UseBattery()
    {
        _batterySlider.value = _playerCon.NowBattery;

        if (_batterySlider.value <= 0)
        {
            //����������B
        }

    }
}
