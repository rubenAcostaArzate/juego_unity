using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemigos : MonoBehaviour
{
    int vida;

    public Animator animador;

    public float velocidadSaltoInicial = 500;

    public float velocidadHorizontal = 1;

    public SpriteRenderer sprite;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    void Movimiento()
    {


    }

    public abstract void Atacar();
}
