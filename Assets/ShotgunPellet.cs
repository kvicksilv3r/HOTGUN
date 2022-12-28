using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPellet : MonoBehaviour
{
    public int damage;

    void OnParticleCollision(GameObject other)
    {
        print("I hit a thing: " + other);

        var damageable = other.transform.GetComponentInChildren<DamageableEntity>();

        if (damageable)
        {
            damageable.ApplyDamage(damage);
        }
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
}
