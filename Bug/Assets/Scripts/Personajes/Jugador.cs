using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private Rigidbody _rb;

    public Camera camaraObjetivo;
    
    private int Vida;

    private int Olor;

    private bool EscudoDisponible;

    private bool LlamadoDisponible;

    private bool DobleSaltoDisponible;

    private bool HormonasDisponible;

    private Animator animador;

    public float velocidadSaltoInicial = 500;

    public float velocidadHorizontal = 1;

    public bool enPiso = false;

    public bool enemigo=true;

    private GameObject spriteCarlita;

    private SpriteRenderer sprite;

    public int saltoMax = 1;
    
    public int saltoActual = 0;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody>();
        spriteCarlita = this.gameObject.transform.GetChild(0).gameObject;
        animador = spriteCarlita.GetComponent<Animator>();
        sprite = spriteCarlita.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {

        animador.SetBool("se_mueve",false);
        animador.SetBool("en_piso",enPiso);

        if (Input.GetKeyDown(KeyCode.Space)) {
            Saltar();

        } else if (Input.GetKey(KeyCode.A)) {
            sprite.flipX=true;
            animador.SetBool("se_mueve",true);
            transform.Translate(-0.1f * velocidadHorizontal,0f,0f);

        } else if (Input.GetKey(KeyCode.D)) {
            sprite.flipX=false;
            animador.SetBool("se_mueve",true);
            transform.Translate(0.1f * velocidadHorizontal,0f,0f);

        } else if (Input.GetKey(KeyCode.W)){
            animador.SetBool("se_mueve",true);
            transform.Translate(0f,0f,0.1f * velocidadHorizontal);

        }else if (Input.GetKey(KeyCode.S)) {
            animador.SetBool("se_mueve",true);
            transform.Translate(0f,0f,-0.1f * velocidadHorizontal);

        }else if (Input.GetKey(KeyCode.E)) {
            Debug.Log("Activo mi escudo");

        }else if (Input.GetKey(KeyCode.Q)) {
            Debug.Log("Utilizo mis hormonas");
        }

    }

    public void Saltar()
    {
        if (saltoActual < saltoMax ){
            if (saltoActual == 1){
                animador.SetBool("segundo_salto",true);
            }
            _rb.AddForce(Vector3.up * velocidadSaltoInicial);
            enPiso = false;
            saltoActual += 1;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        enPiso = true;
        saltoActual = 0;
        animador.SetBool("segundo_salto",false); 
    }
}
