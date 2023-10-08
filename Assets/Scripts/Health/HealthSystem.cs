using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    public event EventHandler OnHealthChanged;
    /*
     * 1. Health should be between 0%-100%
     * 2. Health's data type is int, while it calculated by percentage, and health regains by time
     * 3. Health can be decreased under the attacks from objects, e.g. the lights
     * 4. Health can be increased by time after leaving from the light
     * 5. Healing amount = delta time * healing speed
     * 6. Heath bar only show up when the health is not 100%, when it comes full again, it will disappear
     */

    //set the predefined fields of the class
    private int health;
    private int healthMax;

    public HealthSystem (int healthMax) 
    {
        this.healthMax = healthMax;
        health = healthMax;
    }

    public int GetHealth () { return health; }

    public void Damage(int damageAmount) 
    {
        health -= damageAmount;
        if (health < 0) health = 0;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }

    public void Heal(int healAmount) 
    {
        health += healAmount;
        if (health > healthMax) health = healthMax;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }

    public float GetHealthPercent()
    {
        return (float)health / healthMax;
    }

}
