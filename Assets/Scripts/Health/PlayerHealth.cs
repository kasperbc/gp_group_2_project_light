using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider HealthBar;
    public float maxHealth = 100;
    public float currentHealth;
    public Image fill;
    public int index = 1;

    // Start is called before the first frame update
    void Awake()
    {
        HealthBar = GetComponent<Slider>();
        HealthBar.wholeNumbers = false;
        fill = transform.Find("Fill").GetComponent<Image>();
        index = 1;
        fill.fillAmount = 0;
        currentHealth = maxHealth;
    }

    void Update()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("You're hit: " + damage);
        HealthBar.value = currentHealth;
        SliderAmount();
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("You're dead!");
        }
    }

    public void SliderAmount()
    {
        fill.fillAmount = currentHealth / maxHealth;
    }
}






//void OnColiisionEnter2D(Collision2D other)
//{
//    if (other.gameObject.tag == "Light")
//    {

//        TakeDamage(damageAmount);
//        Debug.Log("Hit!");
//        GameObject fill = GameObject.Find("Fill");
//        Image imageHealth = fill.GetComponent<Image>();
//        imageHealth.fillAmount = (maxHealth + 0.0f) / 100;
//        if (maxHealth <= 0)
//        {
//            Destroy(gameObject);
//        }
//    }
//}