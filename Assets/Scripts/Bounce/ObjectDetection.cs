using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    private Transform tf;
    private GameObject go;
    private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Light"))
        {
                go.transform.GetChild(1);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
