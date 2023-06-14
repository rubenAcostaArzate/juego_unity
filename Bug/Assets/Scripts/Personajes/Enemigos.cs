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

    public Rigidbody _rb;

    public int saltoMax = 1;

    public int saltoActual = 0;

    public bool enPiso = false;

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

    private void OnTriggerEnter(Collider other)
    {
        enPiso = true;
        saltoActual = 0;

    }

    public abstract void Atacar();
}
