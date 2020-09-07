using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movimiento : MonoBehaviour
{
    public Rigidbody rb;
    [Space]
    public float velocidadDeMovimiento;
    public float fuerzaDeSalto;
    public float multiplicadorDeCaida = 1;
    [Space]
    public Transform camTransform;
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    float yaw = 0.0f;
    float pitch = 0.0f;
    [Space]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

    float h, v;

    bool jump;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jump = true;

            rb.AddForce(Vector3.up * fuerzaDeSalto);
        }
    }

    private void FixedUpdate()
    {
        //          MOVER
        Vector3 newVelocity = (transform.forward * velocidadDeMovimiento * v + transform.right * velocidadDeMovimiento * h) * Time.fixedDeltaTime;

        rb.velocity = new Vector3(newVelocity.x, rb.velocity.y, newVelocity.z);

        //          Girar
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        camTransform.localEulerAngles = new Vector3(Mathf.Clamp(pitch, -90, 90), 0.0f, 0.0f);
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //if (!isGrounded && (!Input.GetButton("Jump") || rb.velocity.y < 0))
        //{
        //    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y - (multiplicadorDeCaida * Time.deltaTime), rb.velocity.z);
        //}
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
