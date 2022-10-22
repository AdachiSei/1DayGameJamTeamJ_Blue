using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanEnemy : EnemyBase
{
    [SerializeField]
    [Header("¶ˆÚ“®‚ÌÅ‘åˆÚ“®‹——£)")]
    Collider2D _leftPos;

    [SerializeField]
    [Header("‰EˆÚ“®‚ÌÅ‘åˆÚ“®‹——£")]
    Collider2D _rightPos;

    bool _isRightMoving;
    bool _isPause;

    protected override void Awake()
    {
        base.Awake();
        _isMoving = true;
        OnMove();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _leftPos.gameObject)
        {
            _isRightMoving = true;
        }
        else if (collision.gameObject == _rightPos.gameObject)
        {
            _isRightMoving = false;
        }
        if(collision.TryGetComponent(out PlayerController player) && _isMoving)
        {
            player.gameObject.SetActive(false);
        }
    }

    async protected override void OnMove()
    {
        while (true)
        {
            await UniTask.Yield();
            if (!_isPause)
            {
                if (!_isMoving)
                {
                    return;
                }
                if (_isRightMoving)
                {
                    _rb.velocity = Vector2.right * Speed;
                }
                else
                {
                    _rb.velocity = Vector2.left * Speed;
                }
            }
        }
    }

    protected override void LightOn()
    {
        _rb.constraints = RigidbodyConstraints2D.None;
        _rb.velocity = _saveVelocity;
        _isMoving = true;
        OnMove();
    }

    protected override void LightOff()
    {
        _saveVelocity = _rb.velocity;
        _rb.velocity = Vector2.zero;
        _rb.constraints = RigidbodyConstraints2D.FreezePosition;
        _isMoving = false;
    }

    protected override void Pause()
    {
        base.Pause();
        _saveVelocity = _rb.velocity;
        _rb.velocity = Vector2.zero;
        _rb.constraints = RigidbodyConstraints2D.FreezePosition;
        _isPause = true;
    }

    protected override void Restart()
    {
        base.Restart();
        _isPause = false;
        _rb.constraints = RigidbodyConstraints2D.None;
        _rb.velocity = _saveVelocity;
    }
}
