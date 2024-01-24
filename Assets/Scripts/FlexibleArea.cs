using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        RectTransform rectTransform = GetComponent<RectTransform>();

        float leftRightBottomValue = screenWidth / 21.6f;
        float topValue = leftRightBottomValue*8;

        rectTransform.offsetMin = new Vector2(leftRightBottomValue, leftRightBottomValue);
        rectTransform.offsetMax = new Vector2(-leftRightBottomValue, -topValue);

    }

}
