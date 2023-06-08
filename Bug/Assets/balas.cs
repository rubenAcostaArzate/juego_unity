using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balas : MonoBehaviour
{
    public float velocidad;

    public Animator animador;

    private Rigidbody2D body;

    public GameObject bala;

    // Start is called before the first frame update
    void Start()
    {
        body=GetComponent<Rigidbody2D>();
        animador=GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other){
       if(other.gameObject.CompareTag("Mario") || other.gameObject.CompareTag("enemigos") || other.gameObject.CompareTag("pipa")){
           Debug.Log(other);
           Destroy(bala);
       }
    }

    // Update is called once per frame
    void Update()
    {
        body.AddForce(velocidad * Vector2.right);
    }
}
