using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escorpion : Enemigos
{
    private float estadoInicial;
    private bool subir;
    private float constante;
    private float tiempo;

    // Start is called before the first frame update
    void Start()
    {
      estadoInicial=3;
      subir=true;
      constante=0.05f;
      tiempo = 0;
    }

    // Update is called once per frame
    void Update()
    {
      //animador.SetBool("atacando",false);



      if (Input.GetKey(KeyCode.G)) {
            sprite.flipX=false;
            animador.SetBool("movimiento", true);
            transform.Translate(-0.05f * velocidadHorizontal,0f,0f);

       } else if (Input.GetKey(KeyCode.K)) {
            sprite.flipX=true;
            animador.SetBool("movimiento", true);
            transform.Translate(0.05f * velocidadHorizontal,0f,0f);

       } else if (Input.GetKey(KeyCode.J)){
            animador.SetBool("movimiento", true);
            transform.Translate(0f,0f,0.05f * velocidadHorizontal);

       }else if (Input.GetKey(KeyCode.H)) {
	    animador.SetBool("movimiento", true);
            transform.Translate(0f,0f,-0.05f * velocidadHorizontal);

       }else if(Input.GetKey(KeyCode.M)){
          animador.SetBool("atacando",true);

       }
    }

    void FixedUpdate(){
      tiempo += Time.deltaTime;

      if (tiempo >= 2f) {
	  sprite.flipX = !sprite.flipX;
        tiempo = 0f;
    }
    }
    
    private void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("Player") && col.gameObject.GetComponentInChildren<Animator>().GetBool("escudo") == false){
	    animador.SetBool("movimiento",false);
            animador.SetBool("atacando",true);
        }
    }

    public void normalize(){
      animador.SetBool("atacando",false);
    }

    public override void Atacar(){
        Debug.Log("me quiero morir");
    }
}
