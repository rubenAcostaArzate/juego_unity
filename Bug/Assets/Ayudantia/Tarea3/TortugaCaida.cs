using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortugaCaida : MonoBehaviour {

    public float velocidad;

    public Sprite spriteDañado;

    public Transform deteccionSuelo;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-velocidad, rb.velocity.y);
    }

    private void Update() {
        /*RaycastHit2D hit = Physics2D.Raycast(deteccionSuelo.position, Vector2.down, 1f);
        if (!hit) {
            deteccionSuelo.transform.localPosition = new Vector3(-deteccionSuelo.transform.localPosition.x,
                deteccionSuelo.transform.localPosition.y, deteccionSuelo.transform.localPosition.z); 
            velocidad *= -1;
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        }*/
    }

    private void OnCollisionEnter(Collision collision) {
    }
}
