using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PopupWindowAnimation : MonoBehaviour
{
    [SerializeField] private Ease animationEase = Ease.Flash;

    [ContextMenu("Play Animation")]
    public void Play()
    {
        transform.DOScale(1.0f, 1.0f).SetEase(animationEase);
    }
}
