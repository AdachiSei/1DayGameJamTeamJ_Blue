using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalDoor : MonoBehaviour
{
    private Testbool _bool;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            if(player.Key)
            {
                //se��炷
                Debug.Log("�N���A");
                UIManager.Instance.SetActiveClearPanel();
                SoundManager.Instance.PlayBGM(BGMType.Clear);
            }
            
        }
    }

}
