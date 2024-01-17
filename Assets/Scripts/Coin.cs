using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public CoinData coinData;
    public CoinID coinID;
    public RectTransform fakeRectTransform;

    private void Start()
    {
        fakeRectTransform=CoinManager.Instance.fakeRectTransform;
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

    public void DestroyCoin()
    {
        InstantiateFakeCoin();

        coinID = CoinID.None;

        GetComponent<Image>().enabled=false;
        GetComponent<Collider2D>().enabled = false;

        gameObject.name = "3. None(Clone)";
    }

    private void InstantiateFakeCoin()
    {
        GameObject fakeCoinPrefab = coinData.GetCoinObject(coinID);
        GameObject fakeCoin = Instantiate(fakeCoinPrefab, transform.position, Quaternion.identity, fakeRectTransform);
        fakeCoin.AddComponent<FakeCoin>();
        
        RectTransform fakeCoinRectTransform = fakeCoin.GetComponent<RectTransform>();
        if (fakeCoinRectTransform != null)
        {
            fakeCoinRectTransform.sizeDelta = GetComponent<RectTransform>().sizeDelta;
        }

        fakeCoin.transform.SetParent(fakeRectTransform);
    }


}

