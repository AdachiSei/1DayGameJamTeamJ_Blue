using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBattery : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            Debug.Log("バッテリーを拾った。");

            SoundManager.Instance.PlaySFX(SFXType.ItemGet);

            player.BatteryExchange();
            ///<summary>バッテリーの残量を全回復する.</summary>
            gameObject.SetActive(false);
        }
    }
}
