using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovForceAnim3D : MonoBehaviour{
    private Rigidbody _rb;

    private Animator animador;

    public float fuerzaSaltoInicial;
    
    public float fuerzaHorizontal;

    public float velocidadTerminal;

    public float velocidadRotacion;
    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody>();
        animador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            _rb.AddForce(fuerzaSaltoInicial * Vector3.up);
        } 
        float targetAngles = transform.rotation.eulerAngles.y;
        float velocidadActual = 0;
        if (Input.GetKey(KeyCode.A)) {
            targetAngles -= 90;
        } 
        if (Input.GetKey(KeyCode.D)) {
            targetAngles += 90;
        }
        targetAngles = Mathf.SmoothDampAngle(transform.rotation.eulerAngles.y, targetAngles, ref velocidadActual,
            velocidadRotacion * Time.deltaTime);
        transform.rotation = Quaternion.Euler(new Vector3(0,targetAngles,0));
        
        
        animador.SetInteger("moveZ",0);
        if (Input.GetKey(KeyCode.W)) {
            animador.SetInteger("moveZ",1);
            _rb.AddForce(fuerzaHorizontal * transform.forward);
        } 
        if (Input.GetKey(KeyCode.S)) {
            animador.SetInteger("moveZ",1);
            _rb.AddForce(fuerzaHorizontal * -transform.forward);
        }
        if(_rb.velocity.x>velocidadTerminal) {
            _rb.velocity = new Vector3(velocidadTerminal, _rb.velocity.y, _rb.velocity.z);
        }
        if(_rb.velocity.x<-velocidadTerminal) {
            _rb.velocity = new Vector3(-velocidadTerminal, _rb.velocity.y, _rb.velocity.z);
        }
        if(_rb.velocity.z>velocidadTerminal) {
            _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, velocidadTerminal);
        }
        if(_rb.velocity.z<-velocidadTerminal) {
            _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, -velocidadTerminal);
        }
    }
}
