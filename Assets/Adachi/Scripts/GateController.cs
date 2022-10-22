using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    [SerializeField]
    [Header("開く距離")]
    float _limitRange;

    [SerializeField]
    [Header("スピード")]
    float _speed;

    float _defalutRange;

    bool _isOpen = true;
    bool _isMoving = true;

    private void Awake()
    {
        _defalutRange = gameObject.transform.position.y;
    }

    async private void OnOpen()
    {
        while(true)
        {
            await UniTask.Yield();
            if (!_isMoving)
            {
                return;
            }
            if(gameObject.transform.position.y >= _limitRange)
            {
                gameObject.transform.position =
                    new Vector2(gameObject.transform.position.x,_limitRange);
                _isOpen = false;
                return;
            }
            else
            {
                gameObject.transform.Translate(0f,_speed,0f);
            }
        }
    }

    async private void OnClose()
    {
        while (true)
        {
            await UniTask.Yield();
            if(!_isMoving)
            {
                return;
            }
            if (gameObject.transform.position.y <= _defalutRange)
            {
                gameObject.transform.position =
                    new Vector2(gameObject.transform.position.x, _defalutRange);
                _isOpen = true;
                return;
            }
            else
            {
                gameObject.transform.Translate(0f, -_speed, 0f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerController player))
        {
            Debug.Log(_isOpen);
            if(_isOpen)OnOpen();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            if (!_isOpen)OnClose();
        }
    }

    void LightOn()
    {
        _isMoving = true;
    }

    void LightOff()
    {
        _isMoving = false;
    }
}
