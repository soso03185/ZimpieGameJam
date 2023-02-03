using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KJH_HpBar : MonoBehaviour
{
    public Text myText;
    public Image Hp_Bar;
    
    float damageTime;
    float timeCount = 0;

    public void Update()
    {
        timeCount += Time.deltaTime;
        myText.text = timeCount.ToString();

        damageTime = Time.deltaTime / 15;
        Hp_Bar.fillAmount -= damageTime;
    }
}
