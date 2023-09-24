using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

/// <summary>
/// This script controls the behaviour for the light
/// that hurts the player.
/// </summary>
public class LightBehaviour : MonoBehaviour
{
    private Light2D lightEmitter;
    [Range(3, 15)]
    public int rayAmount = 5;
    void Start()
    {
        lightEmitter = transform.GetChild(0).GetComponent<Light2D>();
    }

    void Update()
    {
        int rayAmnt = rayAmount - 1;
        for (int i = 0; i <= rayAmnt; i++)
        {
            float rayAngleOffset = (lightEmitter.pointLightInnerAngle / 2) - (lightEmitter.pointLightInnerAngle * i / rayAmnt);

            Vector3 rayDirection = transform.up;
            rayDirection = Quaternion.Euler(0, 0, rayAngleOffset) * rayDirection;

            float rayDistance = lightEmitter.pointLightOuterRadius * (1 - lightEmitter.falloffIntensity);

            RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, rayDirection, rayDistance);

            Color debugColor = Color.green;
            if (raycastHit)
            {
                if (raycastHit.transform.gameObject.CompareTag("Player"))
                {
                    Debug.Log("Hit player!");
                    debugColor = Color.red;
                }
            }

            Debug.DrawRay(transform.position, rayDirection * rayDistance, debugColor, 0);
        }
    }
}
