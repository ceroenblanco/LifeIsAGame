using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Disparar : MonoBehaviour
{
    public AudioSource audioSource;

    public TipoDeDisparo disparo;

    public Transform ptoAparicionDisparo;

    float t = 0;

    private void Awake()
    {
        audioSource.clip = disparo.sondio;
    }

    private void Start()
    {
        t = disparo.disparosPorSegundo;
    }

    private void Update()
    {
        t += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && t >= 1 / disparo.disparosPorSegundo)
        {
            Vector3 newRot = ptoAparicionDisparo.rotation.eulerAngles - new Vector3(disparo.anguloInclinacionInicial, 0, 0);

            GameObject go_disparo = (GameObject)Instantiate(disparo.prefab_proyectil, ptoAparicionDisparo.position, Quaternion.Euler(newRot));

            Proyectil newProyectil = go_disparo.GetComponent<Proyectil>();

            newProyectil.velocidad = disparo.velocidadDeProyectil;

            newProyectil.multiplicadorGravedad = disparo.multiplicadorDeGravedad;

            audioSource.Stop();
            audioSource.Play();

            t = 0;
        }
    }

    public void CambiarArma (TipoDeDisparo newDisparo)
    {
        disparo = newDisparo;

        audioSource.clip = disparo.sondio;
    }
}
