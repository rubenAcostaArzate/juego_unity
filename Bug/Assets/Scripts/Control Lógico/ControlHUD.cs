using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Jugador;

public class ControlHUD : MonoBehaviour
{
    int saludJugador;
    public Jugador carlita;

    // Start is called before the first frame update
    void Start()
    {
        saludJugador = carlita.getVida();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
