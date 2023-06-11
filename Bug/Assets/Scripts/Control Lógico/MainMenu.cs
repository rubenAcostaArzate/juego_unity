using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int i;

    public void CargarEscena(string siguienteEscena)
    {
        SceneManager.LoadScene(siguienteEscena);
    }

    public void SalirJuego()
    {
        Application.Quit();
    }

    public void OtraVez(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+i);
        //SceneManager.LoadScene(Carlita.getNivel());
    }
}
