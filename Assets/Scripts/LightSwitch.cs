using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightSwitch : MonoBehaviour
{
    public GameObject intIcon, myLight, levelUpCube;
    public bool toggle;
    public AudioSource lightSwitchSound;

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        intIcon.SetActive(true);
    //        if (Input.GetKeyDown(KeyCode.F))
    //        {
    //            if (toggle == true)
    //            {
    //                myLight.SetActive(true);
    //                levelUpCube.SetActive(false);
    //                lightSwitchSound.Play();
    //                Debug.Log("Light On");
    //                Debug.Log("Level up cube N");
    //            }
    //            if (toggle == false)
    //            {
    //                myLight.SetActive(false);
    //                levelUpCube.SetActive(true);
    //                lightSwitchSound.Play();
    //                Debug.Log("Light Off");
    //                Debug.Log("Level up cube Y");
    //            }
    //            toggle = !toggle;
    //        }
    //    }
    //}

    private void ToggleSwitch()
    {
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

    public void Update()
    {
        ToggleSwitch();
    }

    //public void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        intIcon.SetActive(false);
    //    }
    //}
}