using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Ctrl_Escena2 : MonoBehaviour
{
    AudioManager audioManager;

    [SerializeField]
    Fader fader;

    public GameObject player;
    public Animator animPersonaje;

    public GameObject go_panelSalir;

    Player_Movimiento playerMov;
    Player_Disparar playerDisp;

    private void Awake()
    {
        fader.Set_Alfa(1);
        fader.RayTarget(true);

        playerMov = player.GetComponent<Player_Movimiento>();
        playerDisp = player.GetComponent<Player_Disparar>();
    }

    private void Start()
    {
        animPersonaje.SetFloat("Animacion Actual", Datos.animacionSeleccionada);

        StartCoroutine(Rutina_Inicial());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !go_panelSalir.activeSelf)
        {
            ActivarPlayer(false);

            go_panelSalir.SetActive(true);

            Time.timeScale = 0;
        }
    }

    void ActivarPlayer (bool newBool)
    {
        playerMov.enabled = newBool;
        playerDisp.enabled = newBool;
    }

    public void ReproducirSonido (string newNombre)
    {
        if (!audioManager)
            audioManager = FindObjectOfType<AudioManager>();

        audioManager.Play(newNombre);
    }

    public void Btn_Continuar()
    {
        Time.timeScale = 1;

        ActivarPlayer(true);

        go_panelSalir.SetActive(false);
    }

    public void Btn_Salir ()
    {
        StartCoroutine(Rutina_Salir());
    }

    IEnumerator Rutina_Inicial ()
    {
        yield return fader.Fade(0, fader.duracionFade);

        fader.RayTarget(false);

        yield return null;

        yield break;
    }

    IEnumerator Rutina_Salir ()
    {
        Time.timeScale = 1;

        fader.RayTarget(true);

        yield return fader.Fade(1, fader.duracionFade);

        yield return null;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        yield break;
    }
}
