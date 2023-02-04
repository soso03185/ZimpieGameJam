using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

namespace KJH
{
    public class KJH_Score : MonoBehaviour
    {
        public int Score;
        public int nowScore;
        public TextMeshProUGUI ScoreText;
        Coroutine coroutine;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Score += 250;
                coroutine = StartCoroutine(Count(Score, nowScore));
            }

        }
        IEnumerator Count(float target, float current)
        {
            float duration = 0.5f; // 카운팅에 걸리는 시간 설정. 
            float offset = (target - current) / duration; // 

            while (current < target)
            {
                current += offset * Time.deltaTime;
                ScoreText.text = ((int)current).ToString();
                yield return null;
            }

            current = target;
            ScoreText.text = ((int)current).ToString();
            nowScore = Score;
        }

    }
}
