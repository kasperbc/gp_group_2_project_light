using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightSwitch : MonoBehaviour
{
    public GameObject lightSwitch, myLight, levelUpCube, player, intIcon;
    public bool toggle;
    public float distance;
    public AudioSource lightSwitchSound;

    private void ToggleSwitch()
    {        
        if (distance < 3f)
        {
            lightSwitch.SetActive(true);
            Debug.Log("Can press button");
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (toggle == true)
                {
                    myLight.SetActive(true);
                    levelUpCube.SetActive(false);
                    lightSwitchSound.Play();
                    Debug.Log("Light On");
                    Debug.Log("Level up cube N");
                }
                if (toggle == false)
                {
                    myLight.SetActive(false);
                    levelUpCube.SetActive(true);
                    lightSwitchSound.Play();
                    Debug.Log("Light Off");
                    Debug.Log("Level up cube Y");
                }
                toggle = !toggle;
            }
        }
        else
        {
            lightSwitch.SetActive(false);
            Debug.Log("Too far");
        }
    }

    void Update()
    {

        distance = Vector2.Distance(player.transform.position, intIcon.transform.position);
        ToggleSwitch();
    }

    //private void ToggleSwitch()
    //{
    //    LightSwitchRotate[] lightSwitches = FindObjectsOfType<LightSwitchRotate>();

    //    if (Input.GetKeyDown(KeyCode.F))
    //    {
    //        if (toggle == true)
    //        {
    //            if (levelUpCube != null)
    //                levelUpCube.SetActive(false);
    //                myLight.SetActive(true);


    //            if (lightSwitchSound != null)
    //                lightSwitchSound.Play();

    //            foreach (LightSwitchRotate lightSwitch in lightSwitches)
    //            {
    //                lightSwitch.RotateToTarget();
    //            }

    //            Debug.Log("Light On");
    //            Debug.Log("Level up cube N");
    //        }
    //        if (toggle == false)
    //        {
    //            if (levelUpCube != null)
    //                levelUpCube.SetActive(true);
    //                myLight.SetActive(false);

    //            if (lightSwitchSound != null)
    //                lightSwitchSound.Play();

    //            foreach (LightSwitchRotate lightSwitch in lightSwitches)
    //            {
    //                lightSwitch.RotateToInitial();
    //            }

    //            Debug.Log("Light Off");
    //            Debug.Log("Level up cube Y");
    //        }
    //        toggle = !toggle;
    //    }
    //}

    //public void Update()
    //{
    //    ToggleSwitch();
    //}

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            intIcon.SetActive(false);
        }
    }
}