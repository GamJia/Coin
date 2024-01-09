using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinData coinData;
    void Start()
    {
        //SetRandomCoinID();
    }
    public void SetRandomCoinID(Transform parent)
    {
        CoinID randomCoinID = (CoinID)Random.Range(0, 4);
        GameObject coinPrefab = coinData.GetCoin(randomCoinID);

        if (coinPrefab != null)
        {
            GameObject coinObject = Instantiate(coinPrefab, parent);
        }
    }

}
