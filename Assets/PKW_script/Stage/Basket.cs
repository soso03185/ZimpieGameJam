using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] private int itemCount;
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer SpriteRenderer;
    public int ItemCount
    {
        get
        {
            return itemCount;
        }
        set
        {
            itemCount = value;
            ChangeSprite();
        }
    }

    private void ChangeSprite()
    {
        if (itemCount >= 4) SpriteRenderer.sprite =  sprites[4];
        else if (itemCount >= 3) SpriteRenderer.sprite = sprites[3];
        else if (itemCount >= 2) SpriteRenderer.sprite = sprites[2];
        else if (itemCount >= 1) SpriteRenderer.sprite = sprites[1];

        else SpriteRenderer.sprite = sprites[0];


    }

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
}
