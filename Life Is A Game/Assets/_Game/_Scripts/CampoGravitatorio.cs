using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampoGravitatorio : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    GameObject prefab_campo, go_visual;

    List<GameObject> objetosCercanos = new List<GameObject>();

    public float duracion = 3;

    private void Start()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        Vector3 newRot = transform.rotation.eulerAngles;

        newRot.x = 0;

        transform.rotation = Quaternion.Euler(newRot);

        StartCoroutine(Rutina_Destruir(duracion));

        LeanTween.rotateZ(go_visual, go_visual.transform.rotation.eulerAngles.z + 180, 1f).setLoopCount(20);
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (duracion > 0 && other.CompareTag("Objeto") && other.transform.parent == null && !objetosCercanos.Contains(other.gameObject))
        {
            GameObject go_newCampo = (GameObject)Instantiate(prefab_campo, transform.position, Quaternion.identity, transform);

            go_newCampo.GetComponent<CampoGravitatorio_Objeto>().objeto = other.transform;

            objetosCercanos.Add(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (duracion > 0 && other.CompareTag("Objeto") && other.transform.parent == null && !objetosCercanos.Contains(other.gameObject))
        {
            GameObject go_newCampo = (GameObject)Instantiate(prefab_campo, transform.position, Quaternion.identity, transform);

            go_newCampo.GetComponent<CampoGravitatorio_Objeto>().objeto = other.transform;

            objetosCercanos.Add(other.gameObject);
        }
    }

    IEnumerator Rutina_Destruir (float newDuracion)
    {
        yield return new WaitForSeconds(newDuracion);

        duracion = 0;

        foreach (GameObject go in objetosCercanos)
        {
            go.transform.parent = null;

            go.GetComponent<Rigidbody>().useGravity = true;
        }

        yield return null;

        Destroy(gameObject);

        yield break;
    }
}
