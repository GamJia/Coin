using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Slider timer; 
    [SerializeField] private Image timerFill;
    [SerializeField] private GameObject resetButton;
    [SerializeField] private GameObject score;
    public GameObject coin;
    public GameObject selectionBox;
    public GameObject gameOverUI;

    void Start()
    {
        timer=GetComponent<Slider>();
        StartCoroutine(DecreaseSliderOverTime());
    }


    IEnumerator DecreaseSliderOverTime()
    {
        while (timer.value > 0)
        {
            timer.value -= 1; 
            yield return new WaitForSeconds(1f); 

            if(timer.value>60)
            {
                timerFill.color=new Color32(158,255,158,255);
            }

            else if(timer.value<30)
            {
                timerFill.color=new Color32(255,158,158,255);
                if(timer.value<10)
                {
                    AudioManager.Instance.SetBGMPitch(1.1f);
                }

                
            }

            else
            {
                timerFill.color=new Color32(255,246,158,255);
            }
        }

        coin.SetActive(false);
        selectionBox.SetActive(false);
        AudioManager.Instance.SetBGMPitch(1f);
        resetButton.SetActive(false);
        gameOverUI.SetActive(true);
        score.SetActive(false);

        this.gameObject.SetActive(false);
    }
}
