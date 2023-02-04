using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace KJH
{
    public class KJH_StageButton : MonoBehaviour
    {
        public string StageName;
        public int StageIndex;

        public GameObject CureStartImage;
        public GameObject FaceImage;
        public GameObject PassImage;
        public Button PanelButton;

        private void Start()
        {
            GameObject go = GameObject.Find("DataManager");
            DataManager DM = go.GetComponent<DataManager>();

            Debug.Log("0");

            if (DM.ClearStage_1 && StageIndex == 1)
            {
                PanelButton.enabled = false;
                FaceImage.SetActive(false);
                CureStartImage.SetActive(true);
                PassImage.SetActive(true);
                Debug.Log("1");
            }
            else if (DM.ClearStage_2 && StageIndex == 2)
            {
                PanelButton.enabled = false;
                FaceImage.SetActive(false);
                CureStartImage.SetActive(true);
                PassImage.SetActive(true);
                Debug.Log("2");
            }
            else if (DM.ClearStage_3 && StageIndex == 3)
            {
                PanelButton.enabled = false;
                FaceImage.SetActive(false);
                CureStartImage.SetActive(true);
                PassImage.SetActive(true);
                Debug.Log("3");
            }
            else if (DM.ClearStage_4 && StageIndex == 4)
            {
                PanelButton.enabled = false;
                FaceImage.SetActive(false);
                CureStartImage.SetActive(true);
                PassImage.SetActive(true);
                Debug.Log("4");
            }
            else if (DM.ClearStage_5 && StageIndex == 5)
            {
                PanelButton.enabled = false;
                FaceImage.SetActive(false);
                CureStartImage.SetActive(true);
                PassImage.SetActive(true);
                Debug.Log("5");
            }
        }

        public void StageButton()
        {
            SceneManager.LoadScene($"{StageName}-{StageIndex}");
        }

        public void StartButton()
        {
            SceneManager.LoadScene("KJH_StoryScene");
        }

        public void StageClear()
        {

        }
    }
}