using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Rigidbody _rb;

    private Animator animador;

    public float fuerzaSaltoInicial;
    
    public float fuerzaHorizontal;

    public float velocidadTerminal;
    
    public bool enSuelo;

    public Transform deteccionSuelo;

    public LayerMask capaSuelo; 

    
    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody>();
	animador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        enSuelo = true; 

	animador.SetInteger("Movement",0);
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo == true)
        {
            Saltar();
        }

        if (Input.GetKey(KeyCode.A)	) {
            GetComponent<SpriteRenderer>().flipX = true;
	    animador.SetInteger("Movement",1);
            _rb.AddForce(fuerzaHorizontal * Vector3.left);
        } 
        if (Input.GetKey(KeyCode.D)) {
            GetComponent<SpriteRenderer>().flipX = false;
	    animador.SetInteger("Movement",1);
            _rb.AddForce(fuerzaHorizontal * Vector3.right);
        }
	if (Input.GetKey(KeyCode.W)) {
	    animador.SetInteger("Movement",1);
            _rb.AddForce(fuerzaHorizontal * Vector3.forward);
        }
	if (Input.GetKey(KeyCode.S)) {
	    animador.SetInteger("Movement",1);
            _rb.AddForce(fuerzaHorizontal * Vector3.back);
        }
        if(_rb.velocity.x>velocidadTerminal) {
            _rb.velocity = new Vector2(velocidadTerminal, _rb.velocity.y);
        }
        if(_rb.velocity.x<-velocidadTerminal) {
            _rb.velocity = new Vector2(-velocidadTerminal, _rb.velocity.y);
        }
    }

	// <summary>
    // Método saltar que hace que Mario salte y se muestre la animación, además
	// llama a la corutina Restore().
    // </summary>
    public void Saltar()
    {
        _rb.AddForce(fuerzaSaltoInicial * Vector3.up);
        enSuelo = false;
    }
    
}