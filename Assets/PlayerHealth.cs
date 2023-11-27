using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider HealthBar;
    public float Health = 100;

    public float _currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = Health;
    }

    // Update is called once per frame
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        HealthBar.value = _currentHealth;
    }
}
