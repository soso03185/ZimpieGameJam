using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KJH_ScrollbarController : MonoBehaviour
{
    public Scrollbar scrollbar;

    public void Start()
    {
        scrollbar.value = 0f;
    }
}
