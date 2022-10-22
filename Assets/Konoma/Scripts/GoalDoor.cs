using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalDoor : MonoBehaviour
{
    private Testbool _bool;

    [SerializeField]
    [Header("クリア時に表示するキャンバス")]
    GameObject _clearCanvas;

    void Awake()
    {
        _clearCanvas.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (TryGetComponent(out PlayerController player))
        {
            if(player.Key)
            {
                //seを鳴らす
                Debug.Log("クリア");
                _clearCanvas.SetActive(true);
            }
            
        }
    }

}
