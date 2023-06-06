using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovForceAnimAudio : MonoBehaviour
{
    private Rigidbody2D _rb;

    private Animator animador;

    public float fuerzaSaltoInicial;
    
    public float fuerzaHorizontal;

    public float velocidadTerminal;
    
    public bool enSuelo;
    
    public Transform deteccionSuelo;

    public AudioClip audioSalto;
    
    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if(Physics2D.CircleCast(deteccionSuelo.position,0.1f,Vector2.zero)) {
            enSuelo = true;
        }
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            AudioSource.PlayClipAtPoint(audioSalto, transform.position);
            Saltar();
        } 
        animador.SetInteger("FuerzaHorizontal",0);
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
}
