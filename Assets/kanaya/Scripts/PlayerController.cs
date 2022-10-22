using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer Rend => _rend;

    public bool Light => _light;

    public bool Key => _key;

    [SerializeField]
    SpriteRenderer _rend;

    Animator _anim;
    Rigidbody2D _rb;

    [SerializeField]
    [Header("プレイヤー移動速度")]
    float _moveSpeed;

    [SerializeField]
    [Header("バッテリー容量の初期値")]
    float _batteryAll;

    /// <summary>バッテリー残量</summary>
    float _batteryRemain;

    /// <summary>ライトの判定</summary>
    bool _light;

    /// <summary>鍵の判定</summary>
    bool _key;

    bool _isPause;
    bool _isFirst = true;

    Vector3 _save;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _light = true;
        PauseManager.Instance.OnPause += Pause;
        PauseManager.Instance.OnRestart += Restart;
    }

    // Update is called once per frame
    void Update()
    {   
        if(!_isPause)
        {
            float moveX = Input.GetAxisRaw("Horizontal");

            if (moveX > 0.01f)  _rend.flipX = true; 
            else if (moveX < -0.01f)  _rend.flipX = false; 

            _rb.velocity = new Vector2(moveX * _moveSpeed, _rb.velocity.y);
            _anim.SetBool("Walk", moveX != 0);

            if(_light) _batteryRemain = _batteryAll - Time.deltaTime;
            if(_batteryRemain < 0)
            {
                if(_isFirst)LightManager.Instance.OffLight();
            }

            if (Input.GetKeyDown(KeyCode.Q)) BoolLight();
        }
    }

    private void OnDisable()
    {
        
    }

    /// <summary>アイテム「バッテリー」に触れたらバッテリー残量を全回復</summary>
    public void BatteryExchange()
    {
        _batteryRemain = _batteryAll;
        _isFirst = true;
    }

    /// <summary>ライトの付ける・消すの判定</summary>
    public void BoolLight()
    {
        if (!_light)
        {
            Debug.Log("明かりを灯す");
            _light = true;
            LightManager.Instance.OnLight();
            //ライトを灯す
        }
        else if (_light)
        {
            Debug.Log("明かりを消す");
            _light = false;
            LightManager.Instance.OffLight();
            //ライトを消す
        }
    }

    public void GetKey()
    {
        _key = true;
    }

    void Pause()
    {
        _save = _rb.velocity;
        _rb.velocity = Vector2.zero;
        _rb.constraints = RigidbodyConstraints2D.FreezePosition;
        _isPause = true;
    }

    void Restart()
    {
        _isPause = false;
        _rb.constraints = RigidbodyConstraints2D.None;
        _rb.velocity = _save;
    }
}
