using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class KJH_HpBar : MonoBehaviour
{
    public Image Hp_Bar;
    float damageTime;

    bool isGreen;
    bool isYellow;
    bool isRed;

    public void Update()
    {
        damageTime = Time.deltaTime / 15;
        Hp_Bar.fillAmount -= damageTime;

        // 0 ~ 20 /  20 ~ 80 / 80 ~ 100
        if(Hp_Bar.fillAmount < 0.8f)
        {
            isGreen = false;
            isYellow = true;
            isRed = false;
        }
        else if (Hp_Bar.fillAmount < 0.2f)
        {
            isGreen = false;
            isYellow = false;
            isRed = true;
        }
        else
        {
            isGreen = true;
            isYellow = false;
            isRed = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Hp_Bar.DOColor(new Color(255, 0, 0), 1);    // red
         //   Hp_Bar.DOColor(new Color(255, 192, 0), 1);  // yellow
         //   Hp_Bar.DOColor(new Color(176, 80, 0), 1);   // green
        }
    }

}
