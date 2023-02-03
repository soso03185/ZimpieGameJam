using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KJH
{
    public class KJH_StageButton : MonoBehaviour
    {
        public string StageName;
        public int StageIndex;

        public void StageButton()
        {
            SceneManager.LoadScene($"{StageName}-{StageIndex}");
        }

        public void StartButton()
        {
            SceneManager.LoadScene("KJH_StoryScene");
        }
    }
}