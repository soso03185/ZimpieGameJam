using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 체력의 값을 표현하는 슬라이더 UI
    /// </summary>
    [SerializeField] private Slider healthSlider;

    /// <summary>
    /// 점수를 화면에 표현하는 텍스트 UI
    /// </summary>
    [SerializeField] private TMP_Text scoreText;

    /// <summary>
    /// 대입된 데이터를 바로 UI에 반영하는 HealthProperty
    /// </summary>

    private int healthValue;
    public int HealthValue
    {
        get => healthValue;
        set { healthSlider.value = value; healthValue = value; }
    }

    /// <summary>
    /// 대입된 데이터를 바로 UI에 반영하는 Score Property
    /// </summary>
    private int scoreValue;
    public int ScoreValue
    {
        get => scoreValue;
        set { scoreText.text = value.ToString(); scoreValue = value; }
    }


}
