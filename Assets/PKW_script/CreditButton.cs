using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditButton : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public void OnClick() => UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
}
