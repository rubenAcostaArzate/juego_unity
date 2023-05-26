using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rana : Enemigos
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animador.SetBool("saltando",!enPiso);
        animador.SetBool("Corriendo",false);
        animador.SetBool("golpeado",false);


        if (Input.GetKey(KeyCode.G)) {
            sprite.flipX=true;
            animador.SetBool("Corriendo",true);
            transform.Translate(-0.05f * velocidadHorizontal,0f,0f);

       } else if (Input.GetKey(KeyCode.K)) {
            sprite.flipX=false;
            animador.SetBool("Corriendo",true);
            transform.Translate(0.05f * velocidadHorizontal,0f,0f);

       } else if (Input.GetKey(KeyCode.J)){
            animador.SetBool("Corriendo",true);
            transform.Translate(0f,0f,0.05f * velocidadHorizontal);

       }else if (Input.GetKey(KeyCode.H)) {
            animador.SetBool("Corriendo",true);
            transform.Translate(0f,0f,-0.05f * velocidadHorizontal);

       }else if (Input.GetKey(KeyCode.B)){
           if (saltoActual < saltoMax ){
            if (saltoActual == 1){

            }
            _rb.AddForce(Vector3.up * velocidadSaltoInicial);
            enPiso = false;
            saltoActual += 1;
           }
       }else if (Input.GetKey(KeyCode.N)){
           Atacar();
       }


    }

    public override void Atacar(){
        Debug.Log("pum, le pego");

    }



    private void OnCollisionEnter(Collision col)
    {
       if(col.gameObject.CompareTag("terreno")){
        enPiso = true;
        saltoActual = 0;
        animador.SetBool("segundo_salto",false);
       }

       if(col.gameObject.CompareTag("Player")){

        animador.SetBool("golpeado",true);
       }
    }


}
