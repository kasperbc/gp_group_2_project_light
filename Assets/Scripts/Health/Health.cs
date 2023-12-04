using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public UnityEngine.UI.Image Health_Background, Health_Damage, Health_Heal;
    public float damage;
    public float heal;
    public float maxHealth = 100f;
    private bool startDamage = false;
    private bool startHeal = false;
    [SerializeField]
    public float fadeTime;
    private float temp;
    private float currentHealth = 100f;

    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            if (value < 0)
            {
                currentHealth = 0;
            }
            else if (value > maxHealth)
            {
                currentHealth = maxHealth;
            }
            {
                currentHealth = value;
            }
            //Health_Damage.fillAmount = currentHealth / maxHealth;
            //temp = Health_Background.fillAmount - Health_Damage.fillAmount;
            //startDamage = true;
            Debug.Log(currentHealth);
        }
    }

    void Start()
    {
        Health_Background.fillAmount = 1;
        Health_Damage.fillAmount = Health_Background.fillAmount;
        Health_Heal.fillAmount = Health_Background.fillAmount;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            TakeDamage();
            FadeDamage(Health_Background.fillAmount, fadeTime);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeHeal();
            FadeHeal(Health_Heal.fillAmount, fadeTime);
        }
    }

    public void FadeDamage(float endValue, float duration)
    {
        if (startDamage)
        {
            Health_Damage.fillAmount -= (temp / duration) * Time.deltaTime;
            if (Health_Damage.fillAmount <= endValue)
            {
                startDamage = false;
            }
        }
    }

    public void FadeHeal(float endValue, float duration)
    {
        if (startHeal)
        {
            Health_Heal.fillAmount += (temp / duration) * Time.deltaTime;
            if (Health_Heal.fillAmount >= endValue)
            {
                startHeal = false;
            }
        }
    }

    public void TakeDamage()
    {
        damage = 10f;
        CurrentHealth -= damage;
        Health_Damage.fillAmount = CurrentHealth / maxHealth;
        Health_Heal.fillAmount = Health_Damage.fillAmount;
        startDamage = true;
        Debug.Log("Damage: " + damage);
    }

    public void TakeHeal()
    {

        heal = 5f;
        CurrentHealth += heal;
        Health_Heal.fillAmount = CurrentHealth / maxHealth;
        Health_Damage.fillAmount = Health_Heal.fillAmount;
        startHeal = true;
        Debug.Log("Heal: " + heal);
    }
}
