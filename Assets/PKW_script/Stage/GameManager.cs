using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

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

    /// <summary>
    /// 버튼을 클릭했을때 로비 씬으로 이동하는 클릭이벤트
    /// </summary>
    public void ExitBtnOnClick()
    {
        //Scene load lobby Scene
        Debug.Log("Scene load lobby Scene");
    }

    public void RetryBtnOnClick()
    {
        //Scene reload currentScene
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        Debug.Log("Scene reload currentScene");
    }

    [Space(10)]
    [SerializeField] private int stoneCount;
    [SerializeField] private GameObject stonePrefab;
    public enum SpeedState
    {
        SLOW,
        NORMAL,
        FAST
    };
    [SerializeField] private SpeedState speedState = SpeedState.FAST;
    [SerializeField] private GameObject itemPrefab;
    private void SpawnStone()
    {
        for (int i = 0; i < stoneCount; i++)
        {
            var objClone = Instantiate(stonePrefab);

            float randomX = Random.Range(-9.0f, 9.0f);
            objClone.transform.position = new Vector3(randomX, objClone.transform.position.y);
        }
    }

    private void ChangeItemSpeed()
    {
        switch (speedState)
        {
            case SpeedState.SLOW:
                itemPrefab.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
                break;
            case SpeedState.NORMAL:
                itemPrefab.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
                break;
            case SpeedState.FAST:
                itemPrefab.GetComponent<Rigidbody2D>().gravityScale = 1.5f;
                break;
        }
    }

    bool isOpened = false;
    Tweener tweenner;
    [SerializeField] private PausePanel pausePanel;
    public void AnimatingPausePanel(bool onoff)
    {
        if (onoff)
        {
            tweenner.Kill();
            pausePanel.transform.DOScale(new Vector3(0, 0, 0), 0.25f).SetEase(Ease.InOutExpo);//.OnComplete(() => pausePanel.gameObject.SetActive(false));

            Time.timeScale = 1.0f;

        }
        else
        {

            tweenner.Kill();
            pausePanel.transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetEase(Ease.InExpo).SetEase(Ease.OutBounce).SetUpdate(true);

            Time.timeScale = 0.0f;
        }


    }

    private void Start()
    {
        SpawnStone();
        ChangeItemSpeed();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AnimatingPausePanel(isOpened);
            isOpened = !isOpened;
        }
    }

}
