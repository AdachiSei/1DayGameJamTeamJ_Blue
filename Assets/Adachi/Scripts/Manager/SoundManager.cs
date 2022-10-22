using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
    [SerializeField]
    [Header("�ŏ��ɗ���BGM")]
    BGMType _bGMType;

    [SerializeField]
    [Header("���ʉ��n")]
    SoundSFX[] _soundSFX;

    [SerializeField]
    [Header("BGM�n")]
    SoundBGM[] _soundBGM;

    AudioSource _audioSource;// ����炷���߂̂���

    protected override void Awake()
    {
        base.Awake();
        _audioSource = GetComponent<AudioSource>();
        PlayBGM(_bGMType);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PlaySFX(SFXType.Click);
        }
    }

    /// <summary>BGM��ς���֐�</summary>
    /// <param name="type">�V�[���^�C�v</param>
    public void PlayBGM(BGMType type)
    {
        _audioSource.Stop();
        var s = Array.Find(_soundBGM, e => e.Type == type);
        if (s != null)
        {
            _audioSource.clip = s.Clip;
            _audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioClip�������ł�");
        }
    }

    /// <summary>���ʉ���炷���߂̊֐�</summary>
    /// <param name="type">���ʉ��^�C�v</param>
    public void PlaySFX(SFXType type)
    {
        var s = Array.Find(_soundSFX, e => e.Type == type);
        if (s != null)
        {
            _audioSource.PlayOneShot(s.Clip);
        }
        else
        {
            Debug.LogError("AudioClip���Ȃ��ł�");
        }
    }

    /// <summary>
    /// BGM���~�߂�
    /// </summary>
    public void StopBGM()
    {
        _audioSource.Stop();
    }

    /// <summary>
    /// BGM���ꎞ��~
    /// </summary>
    void Pause()
    {
        _audioSource.Pause();
    }

    /// <summary>
    /// BGM���ĊJ
    /// </summary>
    void Restart()
    {
        _audioSource.UnPause();
    }

    [Serializable]
    public class SoundSFX
    {
        public AudioClip Clip => _clip;

        public SFXType Type => _type;

        [SerializeField]
        SFXType _type;

        [SerializeField]
        AudioClip _clip;

    }

    [Serializable]
    public class SoundBGM
    {
        public AudioClip Clip => _clip;

        public BGMType Type => _type;

        [SerializeField]
        BGMType _type;

        [SerializeField]
        AudioClip _clip;
    }
}
