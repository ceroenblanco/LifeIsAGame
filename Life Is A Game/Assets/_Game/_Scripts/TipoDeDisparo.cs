using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Disparo", menuName = "Disparos")]
public class TipoDeDisparo : ScriptableObject
{
    public GameObject prefab_proyectil;

    public float disparosPorSegundo = 1;

    public float anguloInclinacionInicial = 0;

    public float velocidadDeProyectil;

    public float multiplicadorDeGravedad;

    public AudioClip sondio;
}
