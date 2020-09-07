using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampoGravitatorio_Objeto : MonoBehaviour
{
    public Transform objeto;

    public float velRotacion;

    private void Start()
    {
        transform.LookAt(objeto);

        objeto.parent = transform;

        objeto.GetComponent<Rigidbody>().useGravity = false;
    }

    private void FixedUpdate()
    {
        Vector3 newRot = transform.rotation.eulerAngles;

        newRot.y += velRotacion * Time.deltaTime;

        transform.rotation = Quaternion.Euler(newRot);
    }
}
