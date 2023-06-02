using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    private Rigidbody _rb;
    
    public int Vida = 3;

    private int Olor;

    private bool EscudoDisponible = false;

    private bool LlamadoDisponible = false;

    private bool DobleSaltoDisponible = false;

    private bool HormonasDisponible = false;

    private Animator animador;

    public float velocidadSaltoInicial = 500;

    public float velocidadHorizontal = 1;

    public bool enPiso = false;

    public bool enemigo=true;

    private GameObject spriteCarlita;

    private SpriteRenderer sprite;

    public int saltoMax = 1;
    
    public int saltoActual = 0;

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
        animador.SetBool("escudo", false);
        animador.SetBool("en_piso",enPiso);
        animador.SetBool("hormonas",false);
        animador.SetBool("llamada",false);

        if(Vida==0){
          SceneManager.LoadScene("GameOver");
        }

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
            animador.SetBool("escudo",true);

        }else if (Input.GetKey(KeyCode.Q)) {
            animador.SetBool("hormonas", true);

        }else if (Input.GetKey(KeyCode.R)) {
            animador.SetBool("llamada", true);

        }


        if(DobleSaltoDisponible == true){
            saltoMax = 2;
        }
    }

    public int getVida(){
        return Vida;
    }

    public bool getEscudo(){
      return EscudoDisponible;
    }

    public bool getLlamada(){
      return LlamadoDisponible;
    }

    public bool getDobleSalto(){
      return DobleSaltoDisponible;
    }

    public bool getHormonas(){
      return HormonasDisponible;
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

    private void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("agua")){
            Vida=0;
            //sprite.enabled=false;
        }

        if(col.gameObject.CompareTag("volar")){
            DobleSaltoDisponible=true;
        }

        if(col.gameObject.CompareTag("enemigo")){
           Vida-=1;
        }


    }
}
