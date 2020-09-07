using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo_PickUp : MonoBehaviour
{
    public AudioSource audioSource;

    public GameObject visual;

    public float velRotacion;

    public TipoDeDisparo tipoDeDisparo;

    private void Start()
    {
        LeanTween.moveY(visual, visual.transform.position.y + 0.1f, 0.6f).setLoopPingPong();
    }

    private void FixedUpdate()
    {
        Vector3 newRot = visual.transform.rotation.eulerAngles;

        newRot.y += velRotacion;

        visual.transform.rotation = Quaternion.Euler(newRot);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player") && other.transform.parent.GetComponent<Player_Disparar>().disparo != tipoDeDisparo)
        {
            audioSource.Play();

            other.transform.parent.GetComponentInParent<Player_Disparar>().CambiarArma(tipoDeDisparo);
        }
    }
}
