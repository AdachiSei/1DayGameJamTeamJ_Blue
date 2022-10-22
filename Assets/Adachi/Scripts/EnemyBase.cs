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
    [Header("�X�s�[�h")]
    float _speed;

    protected Rigidbody2D _rb;

    /// <summary>
    /// �x���V�e�B��ۑ�
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
    /// �|�[�Y
    /// </summary>
    protected virtual void LightOn()
    {

    }

    /// <summary>
    /// ���X�^�[�g
    /// </summary>
    protected virtual void LightOff()
    {

    }
}