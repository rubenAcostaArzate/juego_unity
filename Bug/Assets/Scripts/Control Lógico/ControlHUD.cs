using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Jugador;

public class ControlHUD : MonoBehaviour
{
    int saludJugador;
    public Jugador carlita;
    public Image Vida3;
    public Image Vida2;
    public Image Vida1;
    public Image Habilidad1;
    public Image Habilidad2;
    public Image Habilidad3;
    public Image Escudo;
    public RawImage Barra_escudo;

    // Start is called before the first frame update
    void Start()
    {
        saludJugador = carlita.getVida();
    }

    // Update is called once per frame
    void Update()
    {
        if(carlita.getVida()==3){
           Vida1.enabled=true;
           Vida2.enabled=true;
           Vida3.enabled=true;
        }

        if(carlita.getVida()==2){
           Vida1.enabled=true;
           Vida2.enabled=true;
           Vida3.enabled=false;
        }
        
        if(carlita.getVida()==1){
           Vida1.enabled=true;
           Vida2.enabled=false;
           Vida3.enabled=false;
        }

        if(carlita.getVida()==0){
           Vida1.enabled=false;
           Vida2.enabled=false;
           Vida3.enabled=false;
        }

        Escudo.enabled=carlita.getEscudo();

        Habilidad1.enabled=carlita.getLlamada();

        Habilidad2.enabled=carlita.getHormonas();

        Habilidad3.enabled=carlita.getDobleSalto();



    }
}
