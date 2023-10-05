using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject balaGO;
    public GameObject kunaiGO;
    public GameObject spawnPoint;

    public float fireRate;
    public float counter;

    public bool kunai;
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            counter += Time.deltaTime;
            if (counter < fireRate)
                return;
            if (kunai) 
            {
                GameObject newKunai = Instantiate(kunaiGO, spawnPoint.transform.position, spawnPoint.transform.rotation);
                newKunai.transform.Rotate(0, -90, 0);
                Bala newKunaiProps = newKunai.GetComponent<Bala>();
                newKunaiProps.SetKunaiVelocity(50.0f);
                newKunaiProps.SetDamage(6);
                counter = 0;
                return;
            }
            GameObject newBala = Instantiate(balaGO, spawnPoint.transform.position, spawnPoint.transform.rotation);
            Bala newBalaProps = newBala.GetComponent<Bala>();
            newBalaProps.SetVelocity(100.0f);
            counter = 0;
            return;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            counter = fireRate;
            return;
        }
    }

    public void SetFireRate(float fireRate)
    {
        this.fireRate = fireRate;
    }

    public void DeactivateAllWeapons()
    {
        kunai = false;
    }
}
