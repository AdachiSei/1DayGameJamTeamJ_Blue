using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForButonn : MonoBehaviour
{
    [SerializeField]
    Image _panel;

    bool _switch;

    public void True()
    {
        if (!_switch)
        {
            _switch = true;
            _panel.gameObject.SetActive(true);
        }
        else
        {
            _switch = false;
            _panel.gameObject.SetActive(false);
        }
    }
}
