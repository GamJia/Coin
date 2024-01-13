using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public CoinData coinData;
    public CoinID coinID;

    private void Start()
    {
        SetRandomCoinID();
    }
    private void SetRandomCoinID()
    {       
        SetCoinImage((CoinID)Random.Range(0, 4));
    }

    public void SetCoinImage(CoinID currentID)
    {
        Image currentImage=GetComponent<Image>();       
        GameObject coinObject = coinData.GetCoinObject(currentID);
        coinID=currentID;

        if (coinObject != null)
        {
            Image coinImage = coinObject.GetComponent<Image>();

            if (coinImage != null)
            {
                currentImage.sprite = coinImage.sprite;
                gameObject.name = coinID.ToString();
            }
        }

        if(coinID == CoinID.None)
        {
            GetComponent<Collider2D>().enabled=false;
            currentImage.color = new Color(currentImage.color.r, currentImage.color.g, currentImage.color.b, 0f);
        }

    }

    public void DestroyCoin()
    {
        SetCoinImage(CoinID.None);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Image currentImage=GetComponent<Image>();
        currentImage.color = new Color32( 120, 170, 255, 255 );

    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        Image currentImage=GetComponent<Image>();
        currentImage.color = Color.white;
    }


}

