using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CoinID
{
    Gold,
    Silver,
    Copper,
    None,
}

[CreateAssetMenu]
public class CoinData : ScriptableObject
{
    public static CoinData Instance => instance;
    private static CoinData instance;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }

        GenerateDictionary(); 
    }

    [SerializeField] CoinArray[] coinArray;

    Dictionary<CoinID, GameObject> coinDictionary = new Dictionary<CoinID, GameObject>(); 

    void GenerateDictionary()
    {
        for (int i = 0; i < coinArray.Length; i++)
        {
            coinDictionary.Add(coinArray[i].coinID, coinArray[i].coin); 
        }
    }

    public GameObject GetCoinObject(CoinID id)  
    {
        Debug.Assert(coinArray.Length > 0, "No Coin!!");

        if (coinDictionary.Count.Equals(0))
        {
            GenerateDictionary();
        }

        if (coinDictionary.ContainsKey(id))
        {
            return coinDictionary[id];
        }
        else
        {
            return null;
        }
    }
}

[Serializable]
public struct CoinArray
{
    [SerializeField] GameObject _coin; // Image 대신 GameObject으로 변경
    [SerializeField] CoinID _coinID;

    public GameObject coin { get { return _coin; } } // Image 대신 GameObject으로 변경
    public CoinID coinID { get { return _coinID; } }
}
