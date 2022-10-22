using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer Rend => _rend;

    Animator _anim;
    Rigidbody2D _body;

    [SerializeField]
    SpriteRenderer _rend;

    [SerializeField]
    [Header("�v���C���[�ړ����x")]
    float _moveSpeed;

    [SerializeField]
    [Header("�o�b�e���[�e�ʂ̏����l")]
    float _batteryAll;

    /// <summary>�o�b�e���[�c��</summary>
    float _batteryRemain;

    /// <summary>���C�g�̔���</summary>
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

        if (moveX > 0.01f) { _rend.flipX = true; }
        else if (moveX < -0.01f) { _rend.flipX = false; }

        _body.velocity = new Vector2(moveX * _moveSpeed, _body.velocity.y);
        _anim.SetBool("Walk", moveX != 0);

        if(Input.GetKeyDown(KeyCode.Q))
        {
            BoolLight();
        }
    }

    /// <summary>�A�C�e���u�o�b�e���[�v�ɐG�ꂽ��o�b�e���[�c�ʂ�S��</summary>
    public void BatteryExchange() => _batteryRemain = _batteryAll;

    /// <summary>���C�g�̕t����E�����̔���</summary>
    public void BoolLight()
    {
        if (!_light)
        {
            Debug.Log("������𓔂�");
            _light = true;
            //���C�g�𓔂�
        }
        else if (_light)
        {
            Debug.Log("�����������");
            _light = false;
        }
    }

}
