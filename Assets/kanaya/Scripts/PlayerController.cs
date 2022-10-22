using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer Rend => _rend;

    public bool Light => _light;

    [SerializeField]
    SpriteRenderer _rend;

    Animator _anim;
    Rigidbody2D _body;

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

    void Start()
    {
        _anim = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();

        _light = true;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        if (moveX > 0.01f)  _rend.flipX = true; 
        else if (moveX < -0.01f)  _rend.flipX = false; 

        _body.velocity = new Vector2(moveX * _moveSpeed, _body.velocity.y);
        _anim.SetBool("Walk", moveX != 0);

        if(_light) _batteryRemain = _batteryAll - Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q)) BoolLight();

        if (Input.GetKeyDown(KeyCode.E)) BatteryExchange();

    }

    /// <summary>アイテム「バッテリー」に触れたらバッテリー残量を全回復</summary>
    public void BatteryExchange() => _batteryRemain = _batteryAll;

    /// <summary>ライトの付ける・消すの判定</summary>
    public void BoolLight()
    {
        if (!_light)
        {
            Debug.Log("明かりを灯す");
            _light = true;
            //ライトを灯す
        }
        else if (_light)
        {
            Debug.Log("明かりを消す");
            _light = false;
            //ライトを消す
        }
    }

}
