using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detecta_arriba : MonoBehaviour
{

    public TortugaPipas tortugaEncerrada;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other){
      if(other.gameObject.CompareTag("Mario")){
        Debug.Log("Si reconozco a Mario");
        if(tortugaEncerrada.veces==0){
          tortugaEncerrada.vida=1;
          tortugaEncerrada.animador.SetInteger("vida",1);
          tortugaEncerrada.veces+=1;
        }else
        if(tortugaEncerrada.veces==1){
          tortugaEncerrada.vida=0;
          tortugaEncerrada.animador.SetInteger("vida",0);
          //time+=Time.deltaTime;
          //if(time>1){
           //sprite.enabled=false;
           Destroy(tortugaEncerrada);
           //time=0;
        }   //}
      }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
