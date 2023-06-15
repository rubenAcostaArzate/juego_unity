using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovVelocity : MonoBehaviour {

    private Rigidbody2D _rb;

    public float velocidadSaltoInicial;
    
    public float velocidadHorizontal;

    public bool enSuelo;

    public bool enemigo=true;

    public SpriteRenderer sprite;
    
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
        
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo) {
            //sprite.sprite=SuperMario_54;
            _rb.velocity = new Vector2(_rb.velocity.x,velocidadSaltoInicial);
        } else if (Input.GetKey(KeyCode.A)) {
            sprite.flipX=true;
            _rb.velocity = new Vector2(-velocidadHorizontal,_rb.velocity.y);
        } else if (Input.GetKey(KeyCode.D)) {
            sprite.flipX=false;
            _rb.velocity = new Vector2(velocidadHorizontal,_rb.velocity.y);
        }
    }
}