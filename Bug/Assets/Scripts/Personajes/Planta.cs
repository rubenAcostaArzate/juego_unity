using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planta : Enemigos
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //animador.SetBool("atacando",false);
      //animador.SetBool("atacando",false);

      animador.SetBool("Atacando",true);

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
