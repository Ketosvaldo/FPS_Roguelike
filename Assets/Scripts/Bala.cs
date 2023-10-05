using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    Rigidbody rb;
    int damage;

    void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<KennyMovement>().MakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public void SetVelocity(float speed)
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.TransformDirection(Vector3.forward) * speed;
    }

    public void SetKunaiVelocity(float speed)
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.TransformDirection(Vector3.right) * speed;
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
        this.damage *= FindObjectOfType<Stats>().GetDamage();
    }
}
