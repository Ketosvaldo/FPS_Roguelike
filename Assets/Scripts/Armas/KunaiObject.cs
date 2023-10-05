using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiObject : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,rotationSpeed * Time.deltaTime,0);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Disparo props = collision.GetComponent<Disparo>();
            props.DeactivateAllWeapons();
            props.kunai = true;
            props.SetFireRate(0.6f);
            CameraMovement WeaponController = FindObjectOfType<CameraMovement>();
            WeaponController.DeactivateAllModels();
            WeaponController.ActivateWeapon(1);
            Destroy(gameObject);
        }
    }
}
