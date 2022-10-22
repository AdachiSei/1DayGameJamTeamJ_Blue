using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer Rend => _rend;

    public bool Light => _light;

    public bool Key => _key;

    public float NowBattery => _nowBattery;

    public float MaxBattery => _maxBattery;

    [SerializeField]
    SpriteRenderer _rend;

    Animator _anim;
    Rigidbody2D _rb;

    [SerializeField]
    [Header("�v���C���[�ړ����x")]
    float _moveSpeed;

    [SerializeField]
    [Header("�o�b�e���[�e�ʂ̏����l")]
    float _maxBattery;

    /// <summary>�o�b�e���[�c��</summary>
    [SerializeField]
    float _nowBattery;

    /// <summary>���C�g�̔���</summary>
    bool _light;

    /// <summary>���̔���</summary>
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
        _nowBattery = _maxBattery;
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

            if (_light)
            {
                _nowBattery -= Time.deltaTime;
                UIManager.Instance.UseBattery();
            }
            if(_nowBattery < 0)
            {
                if(_isFirst)LightManager.Instance.OffLight();
            }

            if (Input.GetKeyDown(KeyCode.Q)) BoolLight();
        }
    }

    private void OnDisable()
    {
        UIManager.Instance.SetActiveGameOverPanel();
    }

    /// <summary>�A�C�e���u�o�b�e���[�v�ɐG�ꂽ��o�b�e���[�c�ʂ�S��</summary>
    public void BatteryExchange()
    {
        _nowBattery = _maxBattery;
        _isFirst = true;
    }

    /// <summary>���C�g�̕t����E�����̔���</summary>
    void BoolLight()
    {
        if (!_light)
        {
            Debug.Log("������𓔂�");
            _light = true;
            LightManager.Instance.OnLight();
            //���C�g�𓔂�
        }
        else if (_light)
        {
            Debug.Log("�����������");
            _light = false;
            LightManager.Instance.OffLight();
            //���C�g������
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
