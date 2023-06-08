using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovForce : MonoBehaviour
{
    private Rigidbody2D _rb;

    public Animator animador;

    public float fuerzaSaltoInicial;
    
    public float fuerzaHorizontal;

    public float velocidadTerminal;
    
    public bool enSuelo;
    
    public Transform deteccionSuelo;
    
    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if(Physics2D.CircleCast(deteccionSuelo.position,0.1f,Vector2.zero)) {
            enSuelo = true;
        }

        if(_rb.velocity.x < 0){
           GetComponent<SpriteRenderer>().flipX=true;
        } else {
           GetComponent<SpriteRenderer>().flipX=false;
        }

        
        if (Input.GetKeyDown(KeyCode.Space)) {
            _rb.AddForce(fuerzaSaltoInicial * Vector2.up);
        } 
        if (Input.GetKey(KeyCode.A)) {
            _rb.AddForce(fuerzaHorizontal * Vector2.left);
        } 
        if (Input.GetKey(KeyCode.D)) {
            _rb.AddForce(fuerzaHorizontal * Vector2.right);
        }
        if(_rb.velocity.x>velocidadTerminal) {
            _rb.velocity = new Vector2(velocidadTerminal, _rb.velocity.y);
        }
        if(_rb.velocity.x<-velocidadTerminal) {
            _rb.velocity = new Vector2(-velocidadTerminal, _rb.velocity.y);
        }
    }
}
