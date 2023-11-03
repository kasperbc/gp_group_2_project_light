using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    float initialRotation;

    public float rotationAmount = 45;
    public float rotationSpeed = 1;
    void Start()
    {
        initialRotation = transform.eulerAngles.z;
    }
    // Update is called once per frame
    void Update()
    {
        float zRotation = Mathf.Sin(Time.time * rotationSpeed);
        zRotation = zRotation * rotationAmount + initialRotation;

        Vector3 rotation = new Vector3(0, 0, zRotation);

        transform.rotation = Quaternion.Euler(rotation);
    }
}
