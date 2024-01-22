using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Slider timer; 
    public GameObject coin;
    public GameObject selectionBox;

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
        }

        Debug.Log("Time Over");
        coin.SetActive(false);
        selectionBox.SetActive(false);
    }
}
