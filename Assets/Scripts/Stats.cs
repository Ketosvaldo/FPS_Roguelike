using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField]
    int health = 100;
    int maxHealth = 100;

    int damage = 5;

    public void MakeDamage(int damageEnemy)
    {
        health -= damageEnemy;
        if(health <= 0)
            Death();
    }

    public void HealthUp(int health)
    {
        maxHealth += health;
        this.health = maxHealth;
    }

    public int GetDamage()
    {
        return damage;
    }

    public void AddDamage(int damage)
    {
        this.damage += damage;
    }

    void Death()
    {
        Destroy(gameObject);
    }

    public int GetHealth()
    {
        return maxHealth;
    }

    public void SetHealth(int newHealthValue)
    {
        maxHealth = newHealthValue;
        health = maxHealth;
    }

    public int GetCurrentHealth()
    {
        return health;
    }
}