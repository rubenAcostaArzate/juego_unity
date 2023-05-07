using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    private Rigidbody _rb;

    private Animator animador;

    public float velocidadSaltoInicial;

    public float velocidadHorizontal;

    public bool enSuelo;

    public bool enemigo=true;

    public SpriteRenderer sprite;

    public Transform deteccionSuelo;


    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody>();
        animador=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

        animador.SetBool("se_mueve",false);
        if(Physics2D.CircleCast(deteccionSuelo.position,0.1f,Vector2.zero)) {
            enSuelo = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && enSuelo) {
            animador.SetBool("se_mueve",true);
            _rb.velocity = new Vector3(_rb.velocity.x,velocidadSaltoInicial);
        } else if (Input.GetKey(KeyCode.A)) {
            sprite.flipX=false;
            animador.SetBool("se_mueve",true);
            transform.Translate(0.1f,0f,0f);
        } else if (Input.GetKey(KeyCode.D)) {
            sprite.flipX=true;
            animador.SetBool("se_mueve",true);
            transform.Translate(-0.1f,0f,0f);
        } else if (Input.GetKey(KeyCode.W)){
            animador.SetBool("se_mueve",true);
            transform.Translate(0f,0f,-0.1f);

        }else if (Input.GetKey(KeyCode.S)) {
            animador.SetBool("se_mueve",true);
            transform.Translate(0f,0f,0.1f);
        }

    }
}
