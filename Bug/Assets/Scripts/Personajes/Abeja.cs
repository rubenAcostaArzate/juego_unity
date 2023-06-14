using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abeja : Enemigos
{
  private float estadoInicial;
  private bool subir;
  private float constante;
  public Jugador Carlita;

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
            sprite.flipX=true;

            transform.Translate(-0.05f * velocidadHorizontal,0f,0f);

       } else if (Input.GetKey(KeyCode.K)) {
            sprite.flipX=false;

            transform.Translate(0.05f * velocidadHorizontal,0f,0f);

       } else if (Input.GetKey(KeyCode.J)){

            transform.Translate(0f,0f,0.05f * velocidadHorizontal);

       }else if (Input.GetKey(KeyCode.H)) {

            transform.Translate(0f,0f,-0.05f * velocidadHorizontal);

       }else if(Input.GetKey(KeyCode.M)){
          animador.SetBool("atacando",true);
       }
    }

    //Invoke("Atacar",0.5f);

    void FixedUpdate(){
     Rigidbody rb=GetComponent<Rigidbody>();
     if(Carlita.estaActivadoE()){
        rb.velocity=new Vector3(rb.velocity.x,0,rb.velocity.z);
     }else
     rb.velocity=new Vector3(rb.velocity.x,velocidadHorizontal,rb.velocity.z);

    }

    public void OnTriggerEnter(Collider col){

      if(col.CompareTag("muro invisible")){
       velocidadHorizontal *=-1;
     }

    }

    public override void Atacar(){
     /*if(subir==true){
      if((estadoInicial-3<transform.position.y) && (transform.position.y<estadoInicial+3)){
        transform.Translate(0f,constante * velocidadHorizontal,0f);
        //constante+=0.05f;
      }
      subir=false;
      //constante=0.05f;
     }
     else{
     if(subir==false){
      if(estadoInicial-3.0f<transform.position.y ){
         transform.Translate(0f,-constante * velocidadHorizontal,0f);
         //constante+=0.05f;
      }
      subir=true;
      //constante=0.05f;
     }
     }*/
    }

    private void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("Player")){
            animador.SetBool("atacando",true);
            Invoke("normalize",2);
        }
    }

    public void normalize(){
      animador.SetBool("atacando",false);
    }

}
