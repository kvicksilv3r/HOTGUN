using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableEntity : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public virtual void Death()
    {

    }

    public virtual void ApplyDamage(int damage)
    {
        currentHealth -= damage;
        CheckDeath();
    }

    public virtual void ApplyHealing(int healing)
    {
        currentHealth += healing;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public virtual void CheckDeath()
    {
        if (currentHealth <= 0)
        {
            Death();
        }
    }

}
