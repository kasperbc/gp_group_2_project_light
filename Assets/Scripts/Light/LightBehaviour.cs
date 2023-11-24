using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

/// <summary>
/// This script controls the behaviour for the light
/// that hurts the player.
/// 
/// Logic is based on raycasting so knowing what that is
/// will make the code a lot easier to understand.
/// </summary>
public class LightBehaviour : MonoBehaviour
{
    // Refrence to the 2D light
    // Better for performance than doing GetComponent every time
    private Light2D lightEmitter;

    // The amount of rays that are calculated.
    // Larger amount = More accuracy, slower perfromance
    [Range(3, 15)]
    public int rayAmount = 5;
    void Start()
    {
        // Get the 2D light component
        lightEmitter = transform.GetComponent<Light2D>();
    }

    void Update()
    {
        // Because of how the code works, if we don't do this
        // the script will cast one more ray than what "rayAmount" is
        // which isn't really that important but it makes this easier to edit
        int rayAmnt = rayAmount - 1;
        for (int i = 0; i <= rayAmnt; i++)
        {
            // Calculate the angle of this ray
            float rayAngleOffset = (lightEmitter.pointLightInnerAngle / 2) - (lightEmitter.pointLightInnerAngle * i / rayAmnt);

            // Make a Vector3 direction for the ray based on the angle
            Vector3 rayDirection = transform.up;
            rayDirection = Quaternion.Euler(0, 0, rayAngleOffset) * rayDirection;

            // Calculate the distance of the ray based on the "length" of the light
            float rayDistance = lightEmitter.pointLightOuterRadius * (1 - lightEmitter.falloffIntensity);

            // Cast the ray based on prior calculations
            RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, rayDirection, rayDistance);

            Color debugColor = Color.green;
            // If the ray hit something, continue
            if (raycastHit)
            {
                // If the something that the ray hit is the player, continue
                if (raycastHit.transform.gameObject.CompareTag("Player"))
                {
                    // TODO Logic for when the player is hit by a ray
                    Debug.Log("Hit player!");
                    debugColor = Color.red;
                }
            }

            // Draw a line of the ray in the scene view (invisible to the player, used only for debugging)
            // Debug.DrawRay doesn't work exactly like Physics2D.Raycast so it's not 100% accurate but close enough
            Debug.DrawRay(transform.position, rayDirection * rayDistance, debugColor, 0);
        }
    }
}
