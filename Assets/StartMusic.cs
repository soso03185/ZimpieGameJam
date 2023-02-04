using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    [SerializeField] private string songName = "birthofahero";
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayBGM(songName);
    }

}
