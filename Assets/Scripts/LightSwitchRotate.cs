using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchRotate : MonoBehaviour
{
    private bool isRotating;
    [SerializeField] private float targetRotation;
    private float initialRotation;
    private float targetAngle;

    private void Start()
    {
        initialRotation = transform.rotation.eulerAngles.z;
        targetAngle = initialRotation;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, targetAngle), 0.01f);
    }

    public void RotateToTarget()
    {
        targetAngle = targetRotation;
    }

    public void RotateToInitial()
    {
        targetAngle = initialRotation;
    }
}
