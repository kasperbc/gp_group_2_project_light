using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private HealthSystem healthSystem;

    public void Setup(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;

        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
    }

    public void HealthSystem_OnHealthChanged(object sender, System.EventArgs e)
    {
        transform.Find("Player/HealthBar/Bar").localScale = new Vector3 (healthSystem.GetHealthPercent(), 1.2f);
    }

    // Update is called once per frame
    private void Update()
    {
        //transform.Find("Player/Bar").localScale = new Vector3 (healthSystem.GetHealthPercent(), 1.2f);
    }
}
