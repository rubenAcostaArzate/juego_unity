using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abeja : Enemigos
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      animador.SetBool("atacando",false);
      animador.SetBool("golpeada",false);

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

    public override void Atacar(){
        Debug.Log("pum, le pego");
    }

    private void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("Player")){
            animador.SetBool("golpeada",true);
        }
    }

}
