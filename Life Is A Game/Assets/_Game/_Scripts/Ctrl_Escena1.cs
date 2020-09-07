using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Ctrl_Escena1 : MonoBehaviour
{
    AudioManager audioManager;

    public Fader fader;

    public Animator animPersonaje;

    private void Awake()
    {
        fader.Set_Alfa(1);

        fader.RayTarget(true);
    }

    private void Start()
    {
        animPersonaje.SetFloat("Animacion Actual", Datos.animacionSeleccionada);

        StartCoroutine(Rutina_Inicial());
    }

    public void ReproducirSonido (string newNombre)
    {
        if (audioManager == null)
            audioManager = FindObjectOfType<AudioManager>();

        audioManager.Play(newNombre);
    }

    public void Btn_ActualizarAnimacion(int new_i)
    {
        animPersonaje.SetFloat("Animacion Actual", new_i);
    }

    public void Btn_SeleccionarYContinuar ()
    {
        StartCoroutine(Rutina_Continuar());
    }

    IEnumerator Rutina_Inicial ()
    {
        yield return fader.Fade(0, fader.duracionFade);

        yield return null;

        fader.RayTarget(false);

        yield break;
    }

    IEnumerator Rutina_Continuar ()
    {
        fader.RayTarget(true);

        Datos.animacionSeleccionada = (int)animPersonaje.GetFloat("Animacion Actual");

        yield return fader.Fade(1, fader.duracionFade);

        yield return null;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        yield break;
    }
}
