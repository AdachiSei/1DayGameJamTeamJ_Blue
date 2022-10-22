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

    public void SetActiveClearPanel()
    {
        _clearPanel.gameObject.SetActive(true);
    }

    public void SetActiveGameOverPanel()
    {
        _gameOverPanel.gameObject.SetActive(true);
    }
}
