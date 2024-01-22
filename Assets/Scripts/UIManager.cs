using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Button resetButton;
    [SerializeField] private Text countDownText;
    [SerializeField] private Slider timer;
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
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        float countdownDuration = 3f;
        float countdownTimer = countdownDuration;

        while (countdownTimer > 0)
        {
            AudioManager.Instance.PlaySFX(AudioID.CountDown); 
            countDownText.text = countdownTimer.ToString(); 
            yield return new WaitForSeconds(1f);
            countdownTimer--;
            
        }

        CoinManager.Instance.Reset(); 

        resetButton.gameObject.SetActive(true);
        countDownText.gameObject.SetActive(false);
        timer.gameObject.SetActive(true);
        AudioManager.Instance.PlayBGM(); 

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
        scoreTextRectTransform.sizeDelta = new Vector2(((Screen.width / 10)), scoreTextRectTransform.sizeDelta.y);
        scoreTextRectTransform.anchoredPosition = new Vector2(((Screen.width / 10)), -(Screen.width / 20));

        RectTransform resetButtonRectTransform = resetButton.GetComponent<RectTransform>();
        resetButtonRectTransform.anchoredPosition = new Vector2(-(Screen.width / 6), (Screen.width / 6));
        resetButtonRectTransform.sizeDelta = new Vector2(Screen.width / 5, Screen.width / 5);

        resetButton.onClick.AddListener(ResetArea);

        resetButtonText = resetButton.GetComponentInChildren<Text>();
        resetButtonText.fontSize = (int)(Screen.width / 5);

        RectTransform timerRectTransform = timer.GetComponent<RectTransform>();
        timerRectTransform.sizeDelta = new Vector2((Screen.width / 1.125f), (Screen.width / 13.5f));
        timerRectTransform.anchoredPosition = new Vector2(0, -(Screen.width / 7f));

        resetButton.gameObject.SetActive(false);
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
            
            if(score>0)
            {
                CalculateScore(-5);
            }            
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
