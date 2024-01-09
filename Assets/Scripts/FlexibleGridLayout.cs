using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleGridLayout : LayoutGroup
{
    public int rows;
    public int columns;
    public Vector2 cellSize;
    public Vector2 spacing;
    public CoinManager coinManager;

    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();

        float parentWidth=rectTransform.rect.width;
        float parentHeight=rectTransform.rect.height;

        float cellWidth=parentWidth/(columns+2);

        rows=Mathf.RoundToInt((float)(parentHeight/parentWidth)*11);

        cellSize.x=cellWidth;
        cellSize.y=cellWidth;

        float spacingWidth=((parentWidth-padding.right)-(cellWidth*columns))/(columns-1);
        float spacingHeight=((parentHeight-padding.bottom)-(cellWidth*rows))/(rows-1);

        rectTransform.offsetMin = new Vector2(spacingWidth, spacingWidth);
        rectTransform.offsetMax = new Vector2(-spacingWidth, -spacingWidth);

        spacing.x=spacingWidth;
        spacing.y=spacingHeight;

        int columnCount=0;
        int rowCount=0;

        CoinManager coinManager=GetComponent<CoinManager>();

        if(coinManager.isInit)
        {
            for(int i=0;i<rectChildren.Count;i++)
            {
                int effectiveColumns = Mathf.Max(columns, 1);

                rowCount = i / effectiveColumns;
                columnCount = i % effectiveColumns;

                var item=rectChildren[i];

                var xPos=(cellSize.x*columnCount)+(spacing.x*columnCount)+padding.left;
                var yPos=(cellSize.y*rowCount)+(spacing.y*rowCount)+padding.left;

                SetChildAlongAxis(item,0,xPos,cellSize.x);
                SetChildAlongAxis(item,1,yPos,cellSize.y);
            }

            //this.enabled=false;
        }

    }

    public override void CalculateLayoutInputVertical()
    {

    }

    public override void SetLayoutHorizontal()
    {
        
    }

    public override void SetLayoutVertical()
    {

    }
}
