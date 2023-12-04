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
    public float damageAmount = 0.1f;
    public float healAmount = 0.1f;
    public float fadeTime = 2f;
    private readonly float maxHealth = 100;
    private float currentHealth = 100;
    private float damageDiff;
    private float healDiff;
    private bool startDamage = false;
    private bool startHeal = false;
    //private bool isAutoHeal = false;

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
            else
            {
                currentHealth = value;
            }
            Debug.Log(currentHealth);
        }
    }

    void Start()
    {
        Health_Center.fillAmount = 1;
        Health_Foreground.fillAmount = Health_Center.fillAmount;
    }

    void Update()
    {
        FadeDamage(Health_Foreground.fillAmount, fadeTime);
        FadeHeal(Health_Center.fillAmount, fadeTime);
        if (CurrentHealth < maxHealth)
        {
            TakeHeal();
        }
    }

    public void TakeDamage()
    {
        CurrentHealth -= damageAmount;
        Health_Foreground.fillAmount = CurrentHealth / maxHealth;
        damageDiff = Health_Center.fillAmount - Health_Foreground.fillAmount;
        startDamage = true;
        Debug.Log("Damage: " + damageAmount);
    }

    public void TakeHeal()
    {
        CurrentHealth += healAmount;
        Health_Center.fillAmount = CurrentHealth / maxHealth;
        healDiff = Health_Center.fillAmount - Health_Foreground.fillAmount;
        startHeal = true;
        Debug.Log("Heal: " + healAmount);
    }
    
    private void FadeDamage(float endValue, float duration)
    {
        if (startDamage)
        {
            Health_Center.fillAmount -= damageDiff / duration * Time.deltaTime;
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

            Health_Foreground.fillAmount += healDiff / duration * Time.deltaTime;
            if (Health_Foreground.fillAmount >= endValue)
            {
                startHeal = false;
            }
        }
    }

    //public void AutoHeal(bool isHit)
    //{
    //    if (CurrentHealth < maxHealth)
    //    {
    //        isAutoHeal = true;
    //        Debug.Log("Auto heal is available!");
    //    }

    //    if (isHit == true)
    //    {
    //        isAutoHeal = false;
    //        Debug.Log("Auto heal is unavailable!");
    //    }
    //}

    //IEnumerator RunAutoHeal()
    //{
    //    isAutoHeal = true;
    //    yield return new WaitForSeconds(2);
    //}
}