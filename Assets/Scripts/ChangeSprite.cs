using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SettingElement
{
    Option,
    BGM,
    SFX,
}


public class ChangeSprite : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] Sprite normalSprite;
    [SerializeField] Sprite pressedSprite;

    [SerializeField] private SettingElement settingElement;
    
    void Start()
    {
        toggle=GetComponent<Toggle>();
    }

    public void SettingSprite()
    {
        if(toggle.isOn)
        {
            toggle.image.sprite = pressedSprite;
        }

        else
        {
            toggle.image.sprite = normalSprite;
        }

        switch(settingElement)
        {
            case SettingElement.Option:
                UIManager.Instance.ChangeOption(toggle);
                break;

            case SettingElement.BGM:
                AudioManager.Instance.ChangeBGMVolume(toggle);
                break;

            case SettingElement.SFX:
                AudioManager.Instance.ChangeSFXVolume(toggle);
                break;

        }

        
    }
}
