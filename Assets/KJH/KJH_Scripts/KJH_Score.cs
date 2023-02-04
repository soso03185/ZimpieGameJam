using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using System;

namespace KJH
{
    public class KJH_Score : MonoBehaviour
    {
        public int Score;
        public int nowScore;
        public TextMeshProUGUI ScoreText;
        public KJH_HpBar HpBar;
        Coroutine coroutine;
        public Action<int> OnGetScoreEvent;
        public TextMeshProUGUI MaxScoreText;

        private void Start()
        {
            ScoreText = GetComponent<TextMeshProUGUI>();
        }

        public void AddScore(int count)
        {
            int alpha = 0;
            int hpTimerBonus = 0;

            switch (count)
            {
                case 3:
                    alpha = 50;
                    break;
                case 4:
                    alpha = 100;
                    hpTimerBonus = 5;
                    break;
                case 5:
                    alpha = 150;
                    hpTimerBonus = 5;
                    break;
                case 6:
                    alpha = 300;
                    hpTimerBonus = 10;
                    break;
            }

            Score += 250 * count + alpha;
            HpBar.AddTimer(hpTimerBonus);
            coroutine = StartCoroutine(Count(Score, nowScore));
            OnGetScoreEvent?.Invoke(Score);
        }

        IEnumerator Count(float target, float current)
        {
            float duration = 0.5f; // ???????? ?????? ???? ????. 
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
