using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalDoor : MonoBehaviour
{
    private Testbool _bool;

    [SerializeField]
    [Header("�N���A���ɕ\������L�����o�X")]
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
                //se��炷
                Debug.Log("�N���A");
                _clearCanvas.SetActive(true);
            }
            
        }
    }

}
