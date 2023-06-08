using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovForce3D : MonoBehaviour
{
    private Rigidbody _rb;

    public float fuerzaSaltoInicial;
    
    public float fuerzaHorizontal;

    public float velocidadTerminal;
    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            _rb.AddForce(fuerzaSaltoInicial * Vector3.up);
        } 
        if (Input.GetKey(KeyCode.A)) {
            _rb.AddForce(fuerzaHorizontal * Vector3.left);
        } 
        if (Input.GetKey(KeyCode.D)) {
            _rb.AddForce(fuerzaHorizontal * Vector3.right);
        }
        if (Input.GetKey(KeyCode.W)) {
            _rb.AddForce(fuerzaHorizontal * Vector3.forward);
        } 
        if (Input.GetKey(KeyCode.S)) {
            _rb.AddForce(fuerzaHorizontal * Vector3.back);
        }
        /*if(_rb.velocity.x>velocidadTerminal) {
            _rb.velocity = new Vector2(velocidadTerminal, _rb.velocity.y);
        }
        if(_rb.velocity.x<-velocidadTerminal) {
            _rb.velocity = new Vector2(-velocidadTerminal, _rb.velocity.y);
        }*/
    }
}
