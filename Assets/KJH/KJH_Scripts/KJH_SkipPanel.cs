using Febucci.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace KJH
{
    public class KJH_SkipPanel : MonoBehaviour
    {
        public TextAnimatorPlayer textAnimatorPlayer;
        public bool isSkip = false;
        public string StageSceneName;

        public void SkipButton()
        {
            if (isSkip) 
            {
                SceneManager.LoadScene(StageSceneName);
            }
            else
            {
                textAnimatorPlayer.SkipTypewriter();
            }
        }

        public void ShowedText()
        {
            isSkip = true;
        }
    }
}
