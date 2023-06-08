using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionVacios : MonoBehaviour {

    public Tortuga tortugaCaida;

   // public TortugaEncerrada tortugaEncerrada;


    
    
    private void OnTriggerEnter2D(Collider2D other) {
        transform.localPosition = new Vector3(-transform.localPosition.x,
            transform.localPosition.y, transform.localPosition.z); 
        tortugaCaida.velocidad *= -1;
        //Debug.Log(other);
    }
}
