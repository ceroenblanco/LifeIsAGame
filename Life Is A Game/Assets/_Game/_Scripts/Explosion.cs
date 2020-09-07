using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject prefab_explosion;
    [Space]
    public float radioExplosion = 4f;
    public float fuerzaExplosion = 100f;

    public void Explotar ()
    {
        GameObject new_go = (GameObject)Instantiate(prefab_explosion, transform.position, Quaternion.identity);

        GameObject[] objetos = GameObject.FindGameObjectsWithTag("Objeto");

        foreach (GameObject go in objetos)
        {
            float distancia = Vector3.Distance(transform.position, go.transform.position);

            if (distancia <= radioExplosion)
            {
                transform.LookAt(go.transform);

                go.GetComponent<Rigidbody>().AddForce(transform.forward * fuerzaExplosion);
            }
        }

        Destroy(gameObject);
    }
}
