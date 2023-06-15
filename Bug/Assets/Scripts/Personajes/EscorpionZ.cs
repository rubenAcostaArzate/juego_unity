using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscorpionZ : Enemigos
{
    private float estadoInicial;
    private bool subir;
    private float constante;

    // Start is called before the first frame update
    void Start()
    {
      estadoInicial=3;
      subir=true;
      constante=0.05f;
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
      if(animador.GetBool("atacando") == false){
        transform.Translate(0.05f * velocidadHorizontal,0f,-0.05f * velocidadHorizontal);
        animador.SetBool("movimiento", true);
      }
    }

    public void OnTriggerEnter(Collider col){

      if(col.CompareTag("muro invisible")){
        velocidadHorizontal *=-1;
      }
    } 
    
    private void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("Player") && col.gameObject.GetComponentInChildren<Animator>().GetBool("escudo") == false){
	    animador.SetBool("movimiento",false);
            animador.SetBool("atacando",true);
        }else if(col.gameObject.GetComponentInChildren<Animator>().GetBool("escudo") == true){
        velocidadHorizontal *=-1;
      }
    }

    public void normalize(){
      animador.SetBool("atacando",false);
    }

    public override void Atacar(){
        Debug.Log("me quiero morir");
    }
}
