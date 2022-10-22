using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : SingletonMonoBehaviour<PauseManager>
{
    public event Action OnPause;
    public event Action OnRestart;

    bool _isPause;

    const string CANCEL = "Cancel";

    private void Update()
    {
        if(Input.GetButtonDown(CANCEL))
        {
            if (!_isPause) _isPause = true;
            else _isPause = false;
            if(_isPause)
            {
                Debug.Log("Pause");
                OnPause();
            }
            else
            {
                Debug.Log("Restart");
                OnRestart();
            }
        }
    }
}
