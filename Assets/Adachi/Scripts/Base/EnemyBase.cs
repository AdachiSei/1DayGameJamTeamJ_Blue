using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float Speed => _speed;
    public Rigidbody2D Rb => _rb;

    [SerializeField]
    [Header("スピード")]
    float _speed;

    protected Rigidbody2D _rb;

    protected SpriteRenderer _spriteRenderer;

    /// <summary>
    /// ベロシティを保存
    /// </summary>
    protected Vector3 _saveVelocity;

    protected bool _isMoving;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        PauseManager.Instance.OnPause += Pause;
        PauseManager.Instance.OnRestart += Restart;
        LightManager.Instance.LightOn += LightOn;
        LightManager.Instance.LightOff += LightOff;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    protected virtual void OnMove()
    {
        
    }

    protected virtual void LightOn()
    {

    }

    protected virtual void LightOff()
    {

    }

    protected virtual void Pause()
    {

    }

    protected virtual void Restart()
    {

    }
}
