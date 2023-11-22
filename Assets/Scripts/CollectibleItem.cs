using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnItemCollected();
        }
    }

    protected virtual void OnItemCollected()
    {
        print("Item collected!");
    }
}
