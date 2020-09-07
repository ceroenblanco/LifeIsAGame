using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirPorTiempo : MonoBehaviour
{
    [SerializeField]
    float tiempo = 3;

    private void Start()
    {
        Destroy(gameObject, tiempo);
    }
}
