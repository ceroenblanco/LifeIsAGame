using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class Proyectil : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    bool detectarColision;

    [HideInInspector]
    public float velocidad, multiplicadorGravedad = 1;

    public UnityEvent OnImpact;

    private void Start()
    {
        rb.velocity = transform.forward * velocidad;
    }

    private void FixedUpdate()
    {
        Vector3 newVel = rb.velocity;

        newVel.y -= multiplicadorGravedad * Time.fixedDeltaTime;

        rb.velocity = newVel;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!detectarColision || other.CompareTag("Player") || other.CompareTag("Destructor") || other.CompareTag("Item"))
            return;

        OnImpact.Invoke();

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Item"))
            return;

        Destroy(gameObject);
    }
}
