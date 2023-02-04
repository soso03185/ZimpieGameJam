using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class PopupWindow : MonoBehaviour
{
    [SerializeField] private Ease animationEase = Ease.Flash;
    [SerializeField] private Image resultTextImage;
    [SerializeField] private Image resultPeopleImage;
    [SerializeField] private TMP_Text totalScoreText;
    [SerializeField] private TMP_Text totalTimeText;
    [SerializeField] private Sprite winningTitleSprite;
    [SerializeField] private Sprite rosingTitleSprite;
    [SerializeField] private Sprite winningPeopleSprite;
    [SerializeField] private Sprite rosingPeopleSprite;
    

    [ContextMenu("Play Animation")]
    public void Show(bool isWinning, int totalScore, int totalTime)
    {
        if (isWinning) //이겼으면
        {
            resultTextImage.sprite = winningTitleSprite;
            resultPeopleImage.sprite = winningPeopleSprite;
        }
        else //졌으면 
        {
            resultTextImage.sprite = rosingTitleSprite;
            resultPeopleImage.sprite = rosingPeopleSprite;
        }

        totalScoreText.text = "Score : " + totalScore.ToString();
        totalTimeText.text = "Time : " + totalTime.ToString();
        transform.DOScale(1.0f, 1.0f).SetEase(animationEase);
    }
}
