using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : SingletonMonoBehaviour<TimeManager>
{
    public float Timer => _timer;

    float _timer;
    bool _isCount;

    protected override void Awake()
    {
        base.Awake();
        TimerStart();
    }

    void Update()
    {
        if(_isCount)_timer += Time.deltaTime;
    }

    public void TimerStart()
    {
        _isCount = true;
    }

    public void TimerStop()
    {
        _isCount = false;
    }

    public void TimerReset()
    {
        _timer = 0;
    }
}
