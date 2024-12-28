using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Se cierra el programa");
    }

    public GameObject personaje;

    public void Comenzar(string Nivel)
    {
        SceneManager.LoadScene(Nivel);
        Debug.Log("Botón de comenzar presionado");
        personaje.SetActive(true);
        Debug.Log("Personaje activado");
    }
}

