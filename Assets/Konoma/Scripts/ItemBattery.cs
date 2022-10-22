using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBattery : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            Debug.Log("�o�b�e���[���E�����B");
            //SoundManager.Instance.PlaySFX(SFXType.)

            player.BatteryExchange();
            gameObject.SetActive(false);
        }
    }
}
