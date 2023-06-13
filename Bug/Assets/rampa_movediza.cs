using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rampa_movediza : MonoBehaviour
{
    public float velocidadHorizontal;

    public Rigidbody rb;

    public bool dirIzq;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
       rb=GetComponent<Rigidbody>();
       rb.velocity=new Vector3(velocidadHorizontal,rb.velocity.y,rb.velocity.z);
    }

    public void OnTriggerEnter(Collider col){

      if(col.CompareTag("muro invisible")){
        velocidadHorizontal*=0;
        dirIzq=true;
        Invoke("cambioDireccion",2);
      }

      if(col.CompareTag("muro invisible2")){
        velocidadHorizontal*=0;
        dirIzq=false;
        Invoke("cambioDireccion",2);
      }
    }

    public void cambioDireccion(){
       if(dirIzq){
        velocidadHorizontal =-2;
       }

       if(!dirIzq){
        velocidadHorizontal=2;
       }
    }
}
