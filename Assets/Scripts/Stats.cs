using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField]
    int health = 100;
    int damage = 5;

    public void MakeDamage(int damageEnemy)
    {
        health -= damageEnemy;
        if(health <= 0)
            Death();
    }

    public int GetDamage()
    {
        return damage;
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
