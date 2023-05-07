using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
private Rigidbody _rb;

    public float velocidadSaltoInicial;

    public float velocidadHorizontal;

    public bool enSuelo;

    public bool enemigo=true;

    public SpriteRenderer sprite;

    public Transform deteccionSuelo;
    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update() {
        if(Physics2D.CircleCast(deteccionSuelo.position,0.1f,Vector2.zero)) {
            enSuelo = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && enSuelo) {
            _rb.velocity = new Vector3(_rb.velocity.x,velocidadSaltoInicial);
        } else if (Input.GetKey(KeyCode.A)) {
            sprite.flipX=true;
            transform.Translate(0.1f,0f,0f);
        } else if (Input.GetKey(KeyCode.D)) {
            sprite.flipX=false;
            transform.Translate(-0.1f,0f,0f);
        } else if (Input.GetKey(KeyCode.W)){
            transform.Translate(0f,0f,0.1f);

        }else if (Input.GetKey(KeyCode.S)) {
            transform.Translate(0f,-0f,-0.1f);
        }

    }
}
