using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testbool : MonoBehaviour
{
    public bool _getKye;

    private void Start()
    {
        _getKye = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            _getKye = true;
            Debug.Log(_getKye);
        }
    }
}
