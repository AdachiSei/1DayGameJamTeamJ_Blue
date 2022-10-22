using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    [SerializeField]
    [Header("�N���A�̃p�l��")]
    Image _clearPanel;

    [SerializeField]
    [Header("�Q�[���I�[�o�[�̃p�l��")]
    Image _gameOverPanel;

    [SerializeField]
    [Header("�o�b�e���[�c��")]
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
