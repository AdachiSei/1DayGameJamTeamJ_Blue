using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : EnemyBase
{
    [SerializeField]
    [Header("�v���C���[")]
    SpriteRenderer _player;

    bool _isPause;

    protected override void Awake()
    {
        base.Awake();
        _isMoving = false;
        gameObject.SetActive(false);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player) && _isMoving)
        {
            player.gameObject.SetActive(false);
        }
    }

    async protected override void OnMove()
    {
        while(true)
        {
            await UniTask.Yield();
            if (!_isPause)
            {
                if (!_isMoving)
                {
                    return;
                }
                //�v���C���[���E�ɂ���
                bool right = _player.gameObject.transform.position.x >
                                gameObject.transform.position.x;
                //�v���C���[�����ɂ���
                bool left = _player.gameObject.transform.position.x <
                                gameObject.transform.position.x;
                if (!_player.flipX && left)//�v���C���[�����ɂ��ĉE�������Ă�����
                {
                    _rb.velocity = Vector2.zero;
                }
                else if (_player.flipX && right)
                {
                    _rb.velocity = Vector2.zero;
                }
                else
                {
                    Vector2 _follow = _player.transform.position - gameObject.transform.position;
                    _rb.velocity = _follow.normalized * Speed;
                }
            }
        }
    }

    protected override void LightOn()
    {
        //_rb.velocity = Vector2.zero;
        //_saveVelocity = _rb.velocity;
        //_rb.constraints = RigidbodyConstraints2D.FreezeAll;
        gameObject.SetActive(false);
        _isMoving = false;
    }

    protected override void LightOff()
    {
        //_rb.constraints = RigidbodyConstraints2D.None;
        //_rb.velocity = _saveVelocity;
        _isMoving = true;
        gameObject.SetActive(true);
        OnMove();
    }

    protected override void Pause()
    {
        base.Pause();
        _isPause = true;
        _rb.velocity = Vector2.zero;
    }

    protected override void Restart()
    {
        base.Restart();
        _isPause = false;
    }
}
