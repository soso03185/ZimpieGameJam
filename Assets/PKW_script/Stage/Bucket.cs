using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    private int itemCount;
    [SerializeField] private GameManager gameManager;
    public int ItemCount
    {
        get => itemCount;
        set
        {
            //this.gameManager.ScoreValue = value;
            this.itemCount = value;
        }
    }

}
