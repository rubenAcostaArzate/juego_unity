using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortugaPipas : MonoBehaviour {

    public float velocidad;

    private Rigidbody2D rb;

    public bool estaChocando;

    public Transform pipa;

    public Transform pipa2;

    public SpriteRenderer spriteRenderer;

    public bool caminando;

    public int vida;

    public Animator animador;

    public int veces;

    public GameObject tortugaPipas;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        estaChocando=false;
        caminando=false;
        vida=2;
        animador=GetComponent<Animator>();

    }
    
    /*private void OnTriggerEnter2D(Collider2D col){
      if(col.CompareTag("pipa")){
        estaChocando=true;
      } 
    }*/

    private void OnCollisionEnter2D(Collision2D col){
      if(col.gameObject.CompareTag("Mario")){
        Debug.Log("Si reconozco a Mario");
        if(veces==0){
          vida=1;
          animador.SetInteger("vida",1);
          veces+=1;
        }else
        if(veces==1){
          vida=0;
          animador.SetInteger("vida",0);
          //time+=Time.deltaTime;
          //if(time>1){
           //sprite.enabled=false;
           Destroy(tortugaPipas);
           //time=0;
          }
        }
      //}

      if (col.gameObject.CompareTag("pipa")){
          velocidad *=-1;
          spriteRenderer.flipX= !spriteRenderer.flipX;

      }
    }

    private void FixedUpdate() {
        if(vida>1){
          caminando=true;
          animador.SetBool("caminando",true);
          rb.velocity = new Vector2(-velocidad, rb.velocity.y);
        }
    }


    private void Update(){

      if (vida<=1){
       animador.SetInteger("vida",1);
      }

      /*RaycastHit2D rayhit=Physics2D.Raycast(pipa.position, Vector2.left,1f);
      RaycastHit2D rayhit2=Physics2D.Raycast(pipa2.position, Vector2.right,1f);

      if (!rayhit){
          velocidad *=-1;
          spriteRenderer.flipX= !spriteRenderer.flipX;
      }

      if (!rayhit2){
          velocidad *=-1;
          spriteRenderer.flipX= !spriteRenderer.flipX;
      }*/

    }
}
