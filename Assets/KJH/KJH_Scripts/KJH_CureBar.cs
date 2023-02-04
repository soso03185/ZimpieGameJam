using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KJH_CureBar : MonoBehaviour
{
    public GameManager GM;
    public KJH.KJH_Score Score;
    public float CureBarGauge;
    Image myImage;

    private void Start()
    {
        myImage = GetComponent<Image>();
    }

    public void Update()
    {
        CureBarGauge = (float)Score.Score / GM.perfectScore;
        myImage.fillAmount = CureBarGauge;
        Debug.Log("Score : " + Score.Score);
        Debug.Log("perfectScore : " + GM.perfectScore);
    }

}
