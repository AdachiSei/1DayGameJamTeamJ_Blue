using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    [SerializeField]
    [Header("クリアのパネル")]
    Image _clearPanel;

    [SerializeField]
    [Header("ゲームオーバーのパネル")]
    Image _gameOverPanel;

    [SerializeField]
    [Header("バッテリー残量")]
    Slider _batterySlider;

    PlayerController _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _batterySlider.maxValue = _player.MaxBattery;
        _batterySlider.value = _player.NowBattery;
    }

    public void SetActiveClearPanel()
    {
        _clearPanel.gameObject.SetActive(true);
    }

    public void SetActiveGameOverPanel()
    {
        _gameOverPanel.gameObject.SetActive(true);
    }

    public void UseBattery()
    {
        _batterySlider.value = _player.NowBattery;
    }
}
