using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionarAnimacion : MonoBehaviour
{
    public Animator animPersonaje;

    public int cantAnimaciones = 3;

    public void Btn_Seleccionar (int new_i)
    {
        if (new_i >= 1 && new_i <= 3)
        {
            animPersonaje.SetFloat("Animacion Actual", new_i);
        }
    }
}
