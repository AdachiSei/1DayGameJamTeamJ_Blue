using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemKye : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent( out PlayerController player))
        {
            Debug.Log("�����E����");

            SoundManager.Instance.PlaySFX(SFXType.ItemGet);

            gameObject.SetActive(false);
        }
    }
}
