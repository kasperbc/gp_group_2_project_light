using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 1. maxHealth's data type is float, maxHealth is between 0-100f.
/// 2. while it calculated by percentage, and health regains by time.
/// 3. maxHealth can be decreased under the attacks from objects, e.g. the lights.
/// 4. maxHealth can be increased by time after leaving from the light.
/// </summary>

public class Health : MonoBehaviour
{
    public Image Health_Background, Health_Center, Health_Foreground;
    public int damageAmount = 2;
    public int healAmount = 2;
    public float fadeTime = 2f;
    private readonly int maxHealth = 100;
    private int currentHealth = 100;
    private float temp;
    private bool startDamage = false;
    private bool startHeal = false;
    private bool isAutoHeal = false;
    private bool isRunAutoHeal = false;

    public int CurrentHealth
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
            else
            {
                currentHealth = value;
            }
            Debug.Log(currentHealth);
        }
    }

    void Start()
    {
        Health_Background.fillAmount = 1;
        Health_Center.fillAmount = Health_Background.fillAmount;
        Health_Foreground.fillAmount = Health_Background.fillAmount;
    }

    void FixedUpdate()
    {
        if (isAutoHeal && CurrentHealth < maxHealth)
        {
            CurrentHealth += healAmount;
            Health_Center.fillAmount = CurrentHealth / maxHealth;
            temp = Health_Center.fillAmount - Health_Foreground.fillAmount;
            startHeal = true;
            Debug.Log("Heal: " + healAmount);
        }

        if (!isRunAutoHeal && !isRunAutoHeal)
        {
            StartCoroutine(RunAutoHeal());
        }
    }

    void Update()
    {
        FadeDamage(Health_Foreground.fillAmount, fadeTime);
        FadeHeal(Health_Center.fillAmount, fadeTime);
    }

    private void FadeDamage(float endValue, float duration)
    {
        if (startDamage)
        {
            Health_Center.fillAmount -= (temp / duration) * Time.deltaTime;
            if (Health_Center.fillAmount <= endValue)
            {
                startDamage = false;
            }
        }
    }

    private void FadeHeal(float endValue, float duration)
    {
        if (startHeal)
        {
            Health_Foreground.fillAmount += (temp / duration) * Time.deltaTime;
            if (Health_Foreground.fillAmount >= endValue)
            {
                startHeal = false;
            }
        }
    }

    public void TakeDamage()
    {
        CurrentHealth -= damageAmount;
        Health_Foreground.fillAmount = CurrentHealth / maxHealth;
        temp = Health_Center.fillAmount - Health_Foreground.fillAmount;
        startDamage = true;
        Debug.Log("Damage: " + damageAmount);
    }

    public void TakeHeal()
    {
        if (isAutoHeal)
        {
            int diff = (CurrentHealth - maxHealth) / healAmount;
            for (int i = 0; i <= diff; i++)
            {
                CurrentHealth += healAmount;
                Health_Center.fillAmount = CurrentHealth / maxHealth;
                temp = Health_Center.fillAmount - Health_Foreground.fillAmount;
                startHeal = true;
                Debug.Log("Heal: " + healAmount);
            }
        }
        else
        {
            Debug.Log("Heal is unavailable!");
        }
    }

    public void AutoHeal(bool isHit)
    {
        if (isHit == false && CurrentHealth < maxHealth)
        {
            isAutoHeal = true;
            Debug.Log("Auto heal is available!");
        }
        else if (isHit == true || CurrentHealth == maxHealth)
        {
            isAutoHeal = false;
            Debug.Log("Auto heal is unavailable!");
        }
    }

    IEnumerator RunAutoHeal()
    {
        isRunAutoHeal = true;
        yield return new WaitForSeconds(2);
        while (CurrentHealth < maxHealth) 
        {
            TakeHeal();

        }
    }
}
