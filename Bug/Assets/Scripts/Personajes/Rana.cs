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

       }
    }

    public override void Atacar(){
        Debug.Log("pum, le pego");
    }
}
