using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    [SerializeField]
    [Header("床の移動向き")]
    FloorDirType _dirType;

    [SerializeField]
    [Header("移動距離")]
    float _limitRange;

    [SerializeField]
    [Header("スピード")]
    float _speed;

    [SerializeField]
    [Header("待ち時間(ミリ秒)")]
    int _waitTime;

    float _defalutRange;

    bool _isFirstDir = true;
    bool _isMoving = true;
    bool _isPause;

    private void Awake()
    {
        PauseManager.Instance.OnPause += Pause;
        PauseManager.Instance.OnRestart += Restart;
        LightManager.Instance.LightOn += LightOn;
        LightManager.Instance.LightOff += LightOff;
        bool right = _dirType == FloorDirType.Right;
        bool left = _dirType == FloorDirType.Left;
        bool up = _dirType == FloorDirType.Up;
        bool down = _dirType == FloorDirType.Down;
        if (right || left)
        {
            _defalutRange = gameObject.transform.position.x;
        }
        else if (up || down)
        {
            _defalutRange = gameObject.transform.position.y;
        }
        if (down || left)
        {
            _speed *= -1;
            _limitRange *= -1;
        }
        OnMove();
    }

    async private void OnMove()
    {
        switch (_dirType)
        {
            case FloorDirType.Right:
                while (true)
                {
                    await UniTask.Yield();
                    if (!_isPause && !_isMoving)
                    {
                        if (gameObject.transform.position.x >= _limitRange)
                        {
                            await UniTask.Delay(_waitTime);
                            gameObject.transform.position =
                            new Vector2(_limitRange, gameObject.transform.position.y);
                            _isFirstDir = false;
                            OnBack();
                            return;
                        }
                        else
                        {
                            gameObject.transform.Translate(_speed, 0f, 0f);
                        }

                    }
                }
            case FloorDirType.Left:
                while (true)
                {
                    await UniTask.Yield();
                    if (!_isPause && !_isMoving)
                    {
                        if (gameObject.transform.position.x <= _limitRange)
                        {
                            await UniTask.Delay(_waitTime);
                            gameObject.transform.position =
                            new Vector2(_limitRange, gameObject.transform.position.y);
                            _isFirstDir = false;
                            OnBack();
                            return;
                        }
                        else
                        {
                            gameObject.transform.Translate(_speed, 0f, 0f);

                        }
                    }
                }
            case FloorDirType.Up:
                while (true)
                {
                    await UniTask.Yield();
                    if (!_isPause && !_isMoving)
                    {

                        if (gameObject.transform.position.y >= _limitRange)
                        {
                            await UniTask.Delay(_waitTime);
                            gameObject.transform.position =
                            new Vector2(gameObject.transform.position.x, _limitRange);
                            _isFirstDir = false;
                            OnBack();
                            return;
                        }
                        else
                        {
                            gameObject.transform.Translate(0f, _speed, 0f);
                        }
                    }
                }
            case FloorDirType.Down:
                while (true)
                {
                    await UniTask.Yield();
                    if (!_isPause && !_isMoving)
                    {
                        {
                            if (gameObject.transform.position.y <= _limitRange)
                            {
                                await UniTask.Delay(_waitTime);
                                gameObject.transform.position =
                                new Vector2(gameObject.transform.position.x, _limitRange);
                                _isFirstDir = false;
                                OnBack();
                                return;
                            }
                            else
                            {
                                gameObject.transform.Translate(0f, _speed, 0f);
                            }
                        }
                    }
                }
        }
    }

    async private void OnBack()
    {
        switch (_dirType)
        {
            case FloorDirType.Right:
                while (true)
                {
                    await UniTask.Yield();
                    if (!_isPause && !_isMoving)
                    {
                        if (gameObject.transform.position.x <= _defalutRange)
                        {
                            await UniTask.Delay(_waitTime);
                            gameObject.transform.position =
                                new Vector2(_defalutRange, gameObject.transform.position.y);
                            _isFirstDir = true;
                            OnMove();
                            return;
                        }
                        else
                        {
                            gameObject.transform.Translate(-_speed, 0f, 0f);
                        }
                    }
                }
            case FloorDirType.Left:
                while (true)
                {
                    await UniTask.Yield();
                    if (!_isPause && !_isMoving)
                    {
                        if (gameObject.transform.position.x >= _defalutRange)
                        {
                            await UniTask.Delay(_waitTime);
                            gameObject.transform.position =
                                new Vector2(_defalutRange, gameObject.transform.position.y);
                            _isFirstDir = true;
                            OnMove();
                            return;
                        }
                        else
                        {
                            gameObject.transform.Translate(-_speed, 0f, 0f);
                        }
                    }
                }
            case FloorDirType.Up:
                while (true)
                {
                    await UniTask.Yield();
                    if (!_isPause && !_isMoving)
                    {
                        if (gameObject.transform.position.y <= _defalutRange)
                        {
                            await UniTask.Delay(_waitTime);
                            gameObject.transform.position =
                                new Vector2(gameObject.transform.position.x, _defalutRange);
                            _isFirstDir = true;
                            OnMove();
                            return;
                        }
                        else
                        {
                            gameObject.transform.Translate(0f, -_speed, 0f);
                        }
                    }
                }
            case FloorDirType.Down:
                while (true)
                {
                    await UniTask.Yield();
                    if (!_isPause && !_isMoving)
                    {
                        if (gameObject.transform.position.y >= _defalutRange)
                        {
                            await UniTask.Delay(_waitTime);
                            gameObject.transform.position =
                                new Vector2(gameObject.transform.position.x, _defalutRange);
                            _isFirstDir = true;
                            OnMove();
                            return;
                        }
                        else
                        {
                            gameObject.transform.Translate(0f, -_speed, 0f);
                        }
                    }
                }
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

    void Pause()
    {
        _isPause = true;
    }

    void Restart()
    {
        _isPause = false;
    }
}
