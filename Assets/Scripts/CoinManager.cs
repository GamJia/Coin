using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinManager : MonoBehaviour
{
    public GameObject coinPrefab;
    public FlexibleGridLayout flexibleGridLayout;
    public RectTransform Background;
    public bool isInit;
    public int rows;
    private int columns;
    void Awake()
    {
        float parentWidth=Background.rect.width;
        float parentHeight=Background.rect.height;

        rows=flexibleGridLayout.rows;
        columns=flexibleGridLayout.columns;
    }

    void Update()
    {
        if(isAvailable())
        {
            Init();
        }

        if (Input.GetKeyDown("space"))
        {
            Reset();
        }
    }
    bool isAvailable()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        if(!isInit)
        {
            if(flexibleGridLayout.rows<=rows)
            {
                if(screenHeight%screenWidth==0)
                {
                    rows=flexibleGridLayout.rows;
                    columns=flexibleGridLayout.columns;

                    if(rows%columns==0)
                    {
                        return true;
                    }
                    
                }

                else
                {
                    if(flexibleGridLayout.rows<rows)
                    {
                        return true;
                    }
                }
            }
            
        }

        return false;
    }

    void Init()
    {
        
        rows=flexibleGridLayout.rows;
        columns=flexibleGridLayout.columns;

        for(int i=0;i<rows*columns;i++)
        {
            GameObject coinObject = Instantiate(coinPrefab, transform);
        }

        isInit=true;
    }

    void Reset()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        Init();
    }

}
