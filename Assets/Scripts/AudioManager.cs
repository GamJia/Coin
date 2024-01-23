using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance => instance;
    private static AudioManager instance;
   
    [SerializeField] AudioStorage _audioStorage;
    [SerializeField] AudioSource _bgm;
    [SerializeField] AudioSource _sfx;



    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
        
    }
    public void PlayBGM()
    {
        _bgm.Play();
    }

    public void SetBGMPitch(float pitch)
    {
        _bgm.pitch = pitch; 
    }

    public void ChangeBGMVolume(Toggle toggle)
    {
        if(toggle.isOn)
        {
            _bgm.volume = -80f;
        }

        else
        {
            _bgm.volume = 1f;
        }
        
    }

    public void PlaySFX(AudioID id)
    {
        if (_sfx.isPlaying)
        {
            _sfx.Stop();
        }

        _sfx.PlayOneShot(_audioStorage.GetAudio(id));
    }

    public void ChangeSFXVolume(Toggle toggle)
    {
        if(toggle.isOn)
        {
            _sfx.volume = -80f;
        }

        else
        {
            _sfx.volume = 1f;
        }
        
    }

}
