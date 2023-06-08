using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MovForceAnim : MonoBehaviour
{
    private Rigidbody2D _rb;

    private Animator animador;

    public float fuerzaSaltoInicial;
    
    public float fuerzaHorizontal;

    public float velocidadTerminal;
    
    public bool enSuelo;
    
    public Transform deteccionSuelo;

    public int vida;

    public Vector3 fuerza;

    public GameObject bigmario;

    public LayerMask capa_suelo;

    private SpriteRenderer sprite;

    public int saltando;

    public int veces;

    private float time;

    public int coins;

    public TMP_Text texto;



    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();
        sprite=GetComponent<SpriteRenderer>();
        saltando=0;
        vida=2;
    }

    private void OnCollisionEnter2D(Collision2D col){
        Debug.Log("si reconoce el collider");
      if(col.gameObject.CompareTag("enemigos")){
          Debug.Log("Pues si reconoce que entra algo de tipo enemigos");
        if(veces==0){
          vida=1;
          animador.SetInteger("Vida",1);
          veces+=1;
        }else
        if(veces==1){
          vida=0;
          animador.SetInteger("Vida",0);
          //time+=Time.deltaTime;
          //if(time>1){
           sprite.enabled=false;
           Destroy(this);
           time=0;
          //}
        }
      }


    }

    private void OnTriggerEnter2D(Collider2D col){
      if(col.gameObject.CompareTag("moneda")){
         coins+=1;
         texto.text="monedas:"+coins;
      }
    }
    // Update is called once per frame
    void Update() {
        if(Physics2D.CircleCast(deteccionSuelo.position,0.1f,Vector2.zero)) {
            enSuelo = true;
        }
        
        if (Input.GetKey(KeyCode.Space)) {
            saltando=1;
            animador.SetInteger("saltando",1);
            Saltar();
        } 



        if (Input.GetKey(KeyCode.A)) {

            GetComponent<SpriteRenderer>().flipX = true;

            animador.SetInteger("FuerzaHorizontal",1);
            _rb.AddForce(fuerzaHorizontal * Vector2.left);
        } 
        if (Input.GetKey(KeyCode.D)) {
            GetComponent<SpriteRenderer>().flipX = false;
            animador.SetInteger("FuerzaHorizontal",1);
            _rb.AddForce(fuerzaHorizontal * Vector2.right);
        }

        /*if (Input.GetKey(KeyCode.S)){
            vida-=1;
            animador.SetInteger("Vida",1);
            //GetComponent<SpriteRenderer>().sprite=mario_pequeño;
        }*/



        time+=Time.deltaTime;
        if(time>1){
          saltando=0;
          animador.SetInteger("saltando",0);
          animador.SetInteger("FuerzaHorizontal",0);
          time=0;
        }

        if(_rb.velocity.x>velocidadTerminal) {
            _rb.velocity = new Vector2(velocidadTerminal, _rb.velocity.y);
        }

        if(_rb.velocity.x<-velocidadTerminal) {
            _rb.velocity = new Vector2(-velocidadTerminal, _rb.velocity.y);
        }
    }

    public void Saltar() {
        _rb.AddForce(fuerzaSaltoInicial * Vector2.up);
    }

    /*public void FixedUpdate(){
      _rb.AddForce(fuerza);

    }*/
}
