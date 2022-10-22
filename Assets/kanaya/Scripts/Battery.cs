using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    PlayerController _playerCon;

    [SerializeField]
    [Header("バッテリー残量")]
    Slider _batterySlider;

    void Start()
    {
        _batterySlider.maxValue = _playerCon.MaxBattery;
        _batterySlider.value = _playerCon.NowBattery;
    }
    public void UseBattery()
    {
        Debug.Log("現在値：" + _batterySlider.value);

        if (_batterySlider.value >= 50)
        {
            Debug.Log("50以上です");
        }

    }
}
