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
    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();

        float parentWidth=rectTransform.rect.width;
        float parentHeight=rectTransform.rect.height;

        float cellWidth=parentWidth/rows;

        cellSize.x=cellWidth;
        cellSize.y=cellWidth;

        float spacingWidth=parentWidth/45f;
        float spacingHeight=(parentHeight-(cellWidth*rows))/rows+((Mathf.Sqrt(parentWidth/parentHeight)-(parentWidth/parentHeight)));

        spacing.x=spacingWidth;
        spacing.y=spacingHeight;

        padding.left = (int)(parentHeight / 100f);
        padding.right = padding.left;
        padding.top = padding.left;
        padding.bottom = padding.left;

        int columnCount=0;
        int rowCount=0;

        for(int i=0;i<rectChildren.Count;i++)
        {
            rowCount=i/columns;
            columnCount=i%columns;

            var item=rectChildren[i];

            var xPos=(cellSize.x*columnCount)+(spacing.x*columnCount)+padding.left;
            var yPos=(cellSize.y*rowCount)+(spacing.y*rowCount)+padding.top;

            SetChildAlongAxis(item,0,xPos,cellSize.x);
            SetChildAlongAxis(item,1,yPos,cellSize.y);
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
