using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinManager : MonoBehaviour
{
    public FlexibleGridLayout flexibleGridLayout;
    public RectTransform Background;
    public CoinData coinData;
    public RectTransform fakeRectTransform;
    public int rows;
    private int columns;
    private bool isCountDownOver;

    public static CoinManager Instance => instance;
    private static CoinManager instance;


    void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }

        float parentWidth=Background.rect.width;
        float parentHeight=Background.rect.height;

        rows=flexibleGridLayout.rows;
        columns=flexibleGridLayout.columns;
    }
    
    
    void Init()
    {
        rows=flexibleGridLayout.rows;
        columns=flexibleGridLayout.columns;
        

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                int index = row * columns + col;

                if ((row.Equals(rows-1)||(row.Equals(rows-2))) && (col >= columns - 2))
                {
                    GameObject coinObject = coinData.GetCoinObject(CoinID.None);
                    Instantiate(coinObject, transform);
                }
                else
                {
                    GameObject coinObject = coinData.GetCoinObject((CoinID)Random.Range(0, 4));
                    Instantiate(coinObject, transform);
                }
            }
        }

    }

    public void Reset()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        Init();
    }

}
