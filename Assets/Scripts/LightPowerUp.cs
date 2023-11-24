using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class LightPowerUp : MonoBehaviour
{
    public GameObject objectToAffect; // Reference to the specific object you want to affect

    public Light2D light2DComponent; // Expose a public field for the Light2D component

    private const string LightRadiusKey = "LightRadius";
    public float radiusIncreaseAmount = 2f; // Amount by which the radius increases

    // Start is called before the first frame update
    private void Start()
    {

        if (light2DComponent == null)
        {
            Debug.Log("No Light2D component found on this GameObject!");
            enabled = false;
            return;
        }

        light2DComponent.pointLightOuterRadius = GameMeneger.Instance.playerLightRadius;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Light") && other.gameObject == objectToAffect)
        {
            IncreaseRadius();
            Debug.Log("Was interaction with light");

            Invoke("ChangeLevel", 4f);
        }
    }

    private void IncreaseRadius()
    {
        
        light2DComponent.pointLightOuterRadius += radiusIncreaseAmount;
        GameMeneger.Instance.playerLightRadius = light2DComponent.pointLightOuterRadius;
    }


    private void ChangeLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
