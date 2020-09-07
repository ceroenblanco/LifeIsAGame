using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atractor : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    public float distanciaMax = 100f;
    public LayerMask hitLayer;
    public float radio = 4f, fuerza = 500f;

    private void Start()
    {
        StartCoroutine(Rutina());
    }

    IEnumerator Rutina ()
    {
        bool impactado = false;

        GameObject[] objetos = GameObject.FindGameObjectsWithTag("Objeto");

        ray.origin = transform.position;
        ray.direction = transform.forward;

        if (!Physics.Raycast(ray, out hit, distanciaMax, hitLayer))
            yield break;

        yield return null;

        for (int i = 0; i < objetos.Length; i++)
        {
            if (Vector3.Distance(hit.point, objetos[i].transform.position) <= radio)
            {
                Transform obj = objetos[i].transform;

                transform.position = obj.position;

                transform.LookAt(hit.point);

                obj.GetComponent<Rigidbody>().AddForce(transform.forward * fuerza);
            }
        }

        yield return null;

        yield break;
    }
}
