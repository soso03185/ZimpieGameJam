using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class KJH_HpBar : MonoBehaviour
{
    public Image Hp_Image;
    public TextMeshProUGUI TimeCount;

    public float _sec;
    public int _min;

    float damageTime;
    float sumTime;

    public float timer;

    private void Awake()
    {
        Hp_Image = GetComponent<Image>();
    }

    public void Update()
    {
        damageTime = Time.deltaTime / 90;
        Hp_Image.fillAmount -= damageTime;

        sumTime += Time.deltaTime;
        timer = 90 - sumTime;

        if((int)timer > 59)
        {
            _min = 1;
            _sec = timer - 60;
        }
        else
        {
            _min = 0;
            _sec = timer;
        }
        
        if (timer >= 91) timer = 90;
        if (timer <= 0) timer = 0;

        TimeCount.text = string.Format("{0:D1}:{1:D2}", _min, (int)_sec);

        if (Hp_Image.fillAmount >= 0.9f) Hp_Image.DOColor(new Color32(255, 59, 59, 255), 0.3f);
        else if (Hp_Image.fillAmount >= 0.6f) Hp_Image.DOColor(new Color32(255, 160, 59, 255), 0.3f);
        else if (Hp_Image.fillAmount >= 0.3f) Hp_Image.DOColor(new Color32(255, 232, 74, 255), 0.3f);
        else Hp_Image.DOColor(new Color32(128, 227, 255, 255), 0.3f);
    }

    public void AddTimer(int addTime)
    {
        Hp_Image.fillAmount += (Time.deltaTime / 90) * addTime;
        sumTime -= addTime;
    }
}
