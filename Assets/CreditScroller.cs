using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScroller : MonoBehaviour
{
    private float totalTime = 0.0f;
    private void Update()
    {
        this.transform.position += Vector3.up * 150f * Time.deltaTime;
        totalTime += Time.deltaTime;
        if (totalTime >= 13.0f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("KJH_LobbyScene");
        }
    }
}
