using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal; // Include this namespace for Light2D
using UnityEngine.Rendering.Universal;

public class LightPowerUp : MonoBehaviour
{
    public float defaultRadius = 5.0f; // Default radius when the game starts or restarts
    public float radiusIncreaseAmount = 0.1f; // Amount by which the radius increases
    public GameObject objectToAffect; // Reference to the specific object you want to affect

    private Light2D light2DComponent;
    private bool isInteracting = false;

    private const string LightRadiusKey = "LightRadius";

    // Start is called before the first frame update
    private void Start()
    {
        light2DComponent = GetComponent<Light2D>();

        if (light2DComponent == null)
        {
            Debug.Log("No Light2D component found on this GameObject!");
            enabled = false;
            return;
        }

        float savedRadius = PlayerPrefs.GetFloat(LightRadiusKey, defaultRadius);
        light2DComponent.pointLightOuterRadius = savedRadius;
    }

    private void SaveCurrentRadius()
    {
        PlayerPrefs.SetFloat(LightRadiusKey, light2DComponent.pointLightOuterRadius);
        PlayerPrefs.Save();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.gameObject == objectToAffect)
        {
            isInteracting = true;
            IncreaseRadius();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.gameObject == objectToAffect)
        {
            isInteracting = false;
            SaveCurrentRadius(); // Save the current radius when interaction ends
        }
    }

    private void IncreaseRadius()
    {
        if (light2DComponent != null)
        {
            light2DComponent.pointLightOuterRadius += radiusIncreaseAmount;
        }
    }

    private void Update()
    {
        if (isInteracting)
        {
            IncreaseRadius();
        }
    }

    public void ResetLightRadius()
    {
        light2DComponent.pointLightOuterRadius = defaultRadius;
        PlayerPrefs.SetFloat(LightRadiusKey, defaultRadius); // Reset and save default radius
        PlayerPrefs.Save();
    }
}
