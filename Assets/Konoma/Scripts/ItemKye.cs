using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemKye : MonoBehaviour
{
    Testbool _testbool;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent( out PlayerController player))
        {
            Debug.Log("�����E����");

            //SoundManager.Instance.PlaySFX(SFXType.);

            gameObject.SetActive(false);
        }
    }
}
