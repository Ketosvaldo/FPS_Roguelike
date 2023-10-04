using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject bala;
    public GameObject spawnPoint;

    public float fireRate;
    public float counter;
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            counter += Time.deltaTime;
            if (counter < fireRate)
                return;
            GameObject newBala = Instantiate(bala, spawnPoint.transform.position, spawnPoint.transform.rotation);
            Bala newBalaProps = newBala.GetComponent<Bala>();
            newBalaProps.SetVelocity(100.0f);
            counter = 0;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            counter = fireRate;
        }
    }
}
