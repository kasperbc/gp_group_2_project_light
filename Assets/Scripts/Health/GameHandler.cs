using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandller : MonoBehaviour
{
    public Transform objHealthBar;
    public Transform Player;
    public Transform healthBarSpawnPoint;
    //public HealthBar healthBar;

    // Start is called before the first frame update
    private void Start()
    {
        HealthSystem healthSystem = new HealthSystem(100);        

        // gameobject objHealthBar.SetActive
        objHealthBar.transform.gameObject.SetActive(false);
        Transform healthBarTransform = Instantiate(objHealthBar, new Vector3(-7.39f, 5.2f, 0), Quaternion.identity, Player.transform);
        // position constraint component
        // objHealthBar.transform.SetParent(Player, false);
        // objHealthBar.transform.SetPositionAndRotation(new Vector3(0, 1.2f, 0), Quaternion.identity);

        HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();
        healthBar.Setup(healthSystem);

        Debug.Log("maxHealth:" + healthSystem.GetHealth());


    }


}
