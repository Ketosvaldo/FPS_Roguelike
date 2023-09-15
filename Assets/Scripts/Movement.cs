using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal == 0 && vertical == 0)
            return;

        Vector3 direction = (gameObject.transform.forward * vertical + gameObject.transform.right * horizontal) * speed * Time.deltaTime;
        rb.velocity = direction;
    }
}
