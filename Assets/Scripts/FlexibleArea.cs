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

        // 현재 게임 오브젝트의 RectTransform 가져오기
        RectTransform rectTransform = GetComponent<RectTransform>();

        // RectTransform의 속성 설정
        float leftRightBottomValue = screenWidth / 21.6f;
        float topValue = leftRightBottomValue*3;

        rectTransform.offsetMin = new Vector2(leftRightBottomValue, leftRightBottomValue);
        rectTransform.offsetMax = new Vector2(-leftRightBottomValue, -topValue);
    }

}
