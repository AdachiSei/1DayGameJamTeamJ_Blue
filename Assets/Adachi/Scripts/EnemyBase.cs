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

    /// <summary>
    /// ベロシティを保存
    /// </summary>
    protected Vector3 _saveVelocity;

    protected bool _isMoving;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    protected virtual void OnMove()
    {
        
    }


    /// <summary>
    /// ポーズ
    /// </summary>
    protected virtual void LightOn()
    {

    }

    /// <summary>
    /// リスタート
    /// </summary>
    protected virtual void LightOff()
    {

    }
}
