using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractive : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player") || collision.transform.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}
