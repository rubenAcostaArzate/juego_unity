using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    private Rigidbody _rb;

    public int nivel_actual;

    public Transform deteccionSuelo;

    public LayerMask capaDeteccionSuelo;

    public int Vida = 3;

    private int Olor;

    public bool EscudoDisponible = false;

    private bool LlamadoDisponible = false;

    public bool DobleSaltoDisponible = false;

    private bool HormonasDisponible = false;

    private bool Nivel1_Comp=false;

    private Animator animador;

    public float velocidadSaltoInicial = 500;

    public float velocidadHorizontal = 1;

    public bool enPiso = false;

    public bool enemigo=true;

    private GameObject spriteCarlita;

    private SpriteRenderer sprite;

    public int saltoMax = 1;

    public int saltoActual = 0;

    public AudioClip audiosalto;

    public AudioClip audiomuerte;

    public AudioClip audiohabilidad;

    public AudioClip audiodaño;

    public bool escudo_activado;


    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody>();
        spriteCarlita = this.gameObject.transform.GetChild(0).gameObject;
        animador = spriteCarlita.GetComponent<Animator>();
        sprite = spriteCarlita.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {


    }

    void FixedUpdate(){

        animador.SetBool("se_mueve",false);
        animador.SetBool("escudo", false);
        animador.SetBool("en_piso",enPiso);
        animador.SetBool("hormonas",false);
        animador.SetBool("llamada",false);

        /*if (Physics.SphereCast(deteccionSuelo.position, 0.1f, Vector3.down, out RaycastHit hit,
                0.1f, capaDeteccionSuelo)) {
            enPiso = true;
        } else {
            enPiso = false;
        }*/

        if (Input.GetKeyDown(KeyCode.Space)) {

            //fuenteAudio.PlayOneShot(audiosalto);
            Saltar();

        } else if (Input.GetKey(KeyCode.A)) {
            sprite.flipX=true;
            animador.SetBool("se_mueve",true);
            _rb.velocity=new Vector3(-velocidadHorizontal,_rb.velocity.y,0);

        } else if (Input.GetKey(KeyCode.D)) {
            sprite.flipX=false;
            animador.SetBool("se_mueve",true);
            _rb.velocity=new Vector3(velocidadHorizontal,_rb.velocity.y,0);

        } else if (Input.GetKey(KeyCode.W)){
            animador.SetBool("se_mueve",true);
            _rb.velocity=new Vector3(0,_rb.velocity.y,velocidadHorizontal);

        }else if (Input.GetKey(KeyCode.S)) {
            animador.SetBool("se_mueve",true);
             _rb.velocity=new Vector3(0,_rb.velocity.y,-velocidadHorizontal);

        }else if (Input.GetKey(KeyCode.E)) {
                Escudar();
        }

        if(enPiso==true){
          saltoActual=0;
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

    public int getNivel(){
      return nivel_actual;
    }

    public void Escudar(){
      if(EscudoDisponible) {
          //escudo_activado=true;
          animador.SetBool("escudo",true);
          //Invoke("desactivarEscudo",3);
      }
    }

    public bool estaActivadoE(){
      return escudo_activado;
    }

    public void desactivarEscudo(){
      escudo_activado=false;
    }

    public void Saltar()
    {
     if(DobleSaltoDisponible){
        if (saltoActual < saltoMax ){
            if (saltoActual == 1){
                animador.SetBool("segundo_salto",true);

            }
            AudioSource.PlayClipAtPoint(audiosalto,transform.position);
            _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
            _rb.AddForce(Vector3.up * velocidadSaltoInicial);
            enPiso = false;
            saltoActual += 1;
        }
     }else{
       if (saltoActual < 1){
           AudioSource.PlayClipAtPoint(audiosalto,transform.position);
           _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
          _rb.AddForce(Vector3.up * velocidadSaltoInicial);
           enPiso = false;
           saltoActual += 1;
       }
     }

    }

    private void OnTriggerEnter(Collider other)
    {
        //enPiso = true;
        //saltoActual = 0;
        //animador.SetBool("segundo_salto",false);


    }

    private void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("agua")){
            Muerte();
        }

        if(col.gameObject.CompareTag("volar")){
            DobleSaltoDisponible=true;
            nivel_actual=2;
            //AudioSource.PlayClipAtPoint(audiohabilidad,transform.position);
            SceneManager.LoadScene("SegundoSalto");
        }

        if(col.gameObject.CompareTag("escudo")){
            EscudoDisponible=true;
            nivel_actual=3;
            //AudioSource.PlayClipAtPoint(audiohabilidad,transform.position);
            SceneManager.LoadScene("Cuevas");
        }

        if(col.gameObject.CompareTag("corona")){
            SceneManager.LoadScene("Victoria");
        }

        if(col.gameObject.CompareTag("enemigo")){
           Vida-=1;
           AudioSource.PlayClipAtPoint(audiodaño,transform.position);
           if(Vida==0){
            Muerte();
           }
        }

        if(col.gameObject.CompareTag("escorpion") && animador.GetBool("escudo") == false){
           Vida = 0;
           AudioSource.PlayClipAtPoint(audiodaño,transform.position);
           Muerte();
        }


        if(col.gameObject.CompareTag("terreno")){
           enPiso=true;
           saltoActual = 0;
           animador.SetBool("segundo_salto",false);
        }


    }

    private void Muerte(){
      Vida=0;
      //AudioSource.PlayClipAtPoint(audiomuerte,transform.position);
      sprite.enabled=false;
      if(nivel_actual==1){
        SceneManager.LoadScene("GameOver");
      }
      if(nivel_actual==2){
        SceneManager.LoadScene("GameOver2");
      }

      if(nivel_actual==3){
        SceneManager.LoadScene("GameOver3");
      }
    }
}
