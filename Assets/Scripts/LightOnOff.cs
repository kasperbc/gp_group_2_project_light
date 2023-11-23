using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightOnOff : MonoBehaviour
{
    Light2D sceneLight;

    // Start is called before the first frame update
    void Start()
    {
        sceneLight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.F))
        {
            sceneLight.enabled = !sceneLight.enabled;
            Debug.Log("Light Switched");
        }
    }
}
