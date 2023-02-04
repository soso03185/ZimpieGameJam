using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class KJH_HpBar : MonoBehaviour
{
    Image Hp_Bar;
    float damageTime;

    private void Awake()
    {
        Hp_Bar = GetComponent<Image>();
    }
    public void Update()
    {
        damageTime = Time.deltaTime / 15;
        Hp_Bar.fillAmount -= damageTime;

        if (Hp_Bar.fillAmount >= 0.8f)
        {
            Hp_Bar.DOColor(Color.green, 0.6f); // green
        }
        else if (Hp_Bar.fillAmount >= 0.25f)
        {
            Hp_Bar.DOColor(new Color(255, 192, 0), 0.3f); // yellow
        }
        else
        {
            Hp_Bar.DOColor(new Color(255, 0, 0), 0.3f); // red
        }
    }
}
