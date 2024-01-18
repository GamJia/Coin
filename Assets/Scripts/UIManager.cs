using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Button resetButton;
    private Text resetButtonText;
    public static UIManager Instance => instance;
    private static UIManager instance;
    private int score;
    private bool isResetButtonActive = true;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }

    }
    void Start()
    {
        ResizeUI();
    }

    void Update()
    {
        resetButton.interactable = isResetButtonActive;
        resetButtonText.gameObject.SetActive(!isResetButtonActive);
    }

    private void ResizeUI()
    {
        scoreText.fontSize = (int)((Screen.width / 10) * 1.25f);

        RectTransform scoreTextRectTransform = scoreText.rectTransform;
        float desiredWidth = (Screen.width / 10);
        scoreTextRectTransform.sizeDelta = new Vector2(desiredWidth, scoreTextRectTransform.sizeDelta.y);

        scoreTextRectTransform.anchoredPosition = new Vector2(desiredWidth, -(Screen.width / 20));

        RectTransform resetButtonRectTransform = resetButton.GetComponent<RectTransform>();
        resetButtonRectTransform.anchoredPosition = new Vector2(-(Screen.width / 6), (Screen.width / 6));
        resetButtonRectTransform.sizeDelta = new Vector2(Screen.width / 5, Screen.width / 5);

        resetButton.onClick.AddListener(ResetArea);

        resetButtonText = resetButton.GetComponentInChildren<Text>();
        resetButtonText.fontSize = (int)(Screen.width / 5);
    }

    public void CalculateScore(int plusScore)
    {
        score+=plusScore;
        if(score<100)
        {
            string scoreFormat = score.ToString("D3");
            scoreText.text = scoreFormat;
        }

        else
        {
            scoreText.text = score.ToString();
        }
    }

    public void ResetArea()
    {
        if (isResetButtonActive)
        {
            StartCoroutine(CountdownAndDisableButton());
            CoinManager.Instance.Reset(); 
        }
    }

    private IEnumerator CountdownAndDisableButton()
    {
        isResetButtonActive = false;
        float countdownDuration = 3f;
        float countdownTimer = countdownDuration;

        while (countdownTimer > 0)
        {
            resetButtonText.text = countdownTimer.ToString(); 
            yield return new WaitForSeconds(1f);
            countdownTimer--;
        }

        isResetButtonActive = true;
    }

   
}
