using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    static int enemigosTotales;
    public GameObject UpgradeGen;
    public GameObject EnemyLevel2;

    public TextMeshProUGUI life;
    public TextMeshProUGUI speed;
    public TextMeshProUGUI damage;

    private void Start()
    {
        enemigosTotales = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void ReducirEnemigos()
    {
        enemigosTotales -= 1;
        if (enemigosTotales <= 0)
            ActivarUI();
    }

    void ActivarUI()
    {
        UpgradeGen.SetActive(true);
    }

    public void LifeUpd(int health, int healthMax)
    {
        life.text = "Vida: " + health + "/" + healthMax;
    }
    public void DmgUpd(int damage)
    {
        this.damage.text = "Ataque: " + damage;
    }
    public void SpdUpd(int speed)
    {
        this.speed.text = "Velocidad: " + speed; 
    }

    public void ResetEnemyCounter()
    {
        EnemyLevel2.SetActive(true);
        enemigosTotales = 3;
    }
}
