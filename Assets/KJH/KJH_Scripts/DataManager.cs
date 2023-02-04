using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private void Awake()
    {
        var obj = FindObjectsOfType<DataManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool ClearStage_1;
    public bool ClearStage_2;
    public bool ClearStage_3;
    public bool ClearStage_4;
    public bool ClearStage_5;

}
