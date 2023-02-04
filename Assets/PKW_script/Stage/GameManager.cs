using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public bool isClear;
    public int StageIndex;

    /// <summary>
    /// 버튼을 클릭했을때 로비 씬으로 이동하는 클릭이벤트
    /// </summary>
    public void ExitBtnOnClick()
    {
        SceneManager.LoadScene("KJH_StageScene");
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
    [SerializeField] private PopupWindow popupwindow;
    [SerializeField] public int perfectScore = 25000;
    [SerializeField] private KJH.KJH_Score KJH_Score;
    [SerializeField] private KJH_HpBar KJH_HpBar;

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
        KJH_Score.MaxScoreText.text = "/" + perfectScore.ToString();
        KJH_Score.ScoreText.text = "0";
        KJH_Score.OnGetScoreEvent += (score) =>
        {
            Debug.Log(score);
            if (score >= perfectScore)
            {
                isClear = true;
                popupwindow.Show(true, score, (int)KJH_HpBar.sumTime);
            }            
        };

        KJH_HpBar.OnTimeOver += () =>
        {
            popupwindow.Show(false, KJH_Score.Score, 0);
        };
        SoundManager.Instance.PlayBGM("hey");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AnimatingPausePanel(isOpened);
            isOpened = !isOpened;
        }

        if (isClear)
        {
            GameObject go = GameObject.Find("DataManager");
            DataManager DM = go.GetComponent<DataManager>();

            switch (StageIndex)
            {
                case 1:
                    DM.ClearStage_1 = true;
                    break;
                case 2:
                    DM.ClearStage_2 = true;
                    break;
                case 3:
                    DM.ClearStage_3 = true;
                    break;
                case 4:
                    DM.ClearStage_4 = true;
                    break;
                case 5:
                    DM.ClearStage_5 = true;
                    break;

            }
        }
    }

}
