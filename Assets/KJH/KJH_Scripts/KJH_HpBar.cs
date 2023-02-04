using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class KJH_HpBar : MonoBehaviour
{
    public Image Hp_Image;
    float damageTime;

    private void Awake()
    {
        Hp_Image = GetComponent<Image>();
    }

    public void Update()
    {
        damageTime = Time.deltaTime / 15;
        Hp_Image.fillAmount -= damageTime;

        if (Hp_Image.fillAmount >= 0.9f) Hp_Image.DOColor(new Color32(255, 59, 59, 255), 0.3f);
        else if (Hp_Image.fillAmount >= 0.6f) Hp_Image.DOColor(new Color32(255, 160, 59, 255), 0.3f);
        else if (Hp_Image.fillAmount >= 0.3f) Hp_Image.DOColor(new Color32(255, 232, 74, 255), 0.3f);
        else Hp_Image.DOColor(new Color32(128, 227, 255, 255), 0.3f);
    }
}
