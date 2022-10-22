using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : EnemyBase
{
    [SerializeField]
    [Header("プレイヤー")]
    SpriteRenderer _player;

    protected override void Awake()
    {
        base.Awake();
        _isMoving = false;
    }

    async protected override void OnMove()
    {
        while(true)
        {
            await UniTask.Yield();
            if(!_isMoving)
            {
                return;
            }
            //プレイヤーが右にいる
            bool right = _player.gameObject.transform.position.x >
                            gameObject.transform.position.x;
            //プレイヤーが左にいる
            bool left = _player.gameObject.transform.position.x <
                            gameObject.transform.position.x;
            if (!_player.flipX && left)//プレイヤーが左にいて右を向いていたら
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

    protected override void LightOn()
    {
        _rb.velocity = Vector2.zero;
        _saveVelocity = _rb.velocity;
        _rb.constraints = RigidbodyConstraints2D.FreezeAll;
        _isMoving = false;
    }

    protected override void LightOff()
    {
        _rb.constraints = RigidbodyConstraints2D.None;
        _rb.velocity = _saveVelocity;
        _isMoving = true;
        OnMove();
    }
}
