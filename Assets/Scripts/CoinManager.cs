using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinManager : MonoBehaviour
{
    public GameObject Coin;
    public FlexibleGridLayout flexibleGridLayout;
    public RectTransform Background;
    public bool isInit;
    private int rows;
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
        if(flexibleGridLayout.rows<rows&&!isInit)
        {
            Init();
        }
    }

    void Init()
    {
        rows=flexibleGridLayout.rows;
        columns=flexibleGridLayout.columns;

        for(int i=0;i<rows*columns;i++)
        {
            var item=Instantiate(Coin,transform);
        }

        isInit=true;
    }


}
