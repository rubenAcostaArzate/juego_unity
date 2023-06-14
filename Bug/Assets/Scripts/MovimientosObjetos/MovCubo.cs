using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCubo : MonoBehaviour
{
    public bool enSuelo = true;
    private int saltoActual = 1;
    private int saltoMax = 1;
    public float velocidadSaltoInicial = 500;
    public Transform deteccionSuelo;
    private Rigidbody _rb;
    RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(Physics.SphereCast(deteccionSuelo.position, 0.1f, Vector3.down, out hit)) {
            enSuelo = true;
            saltoActual = 1;

        }
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo) {
            Debug.Log("Salto actual: " + saltoActual);
            Saltar();
            Debug.Log("Salto actual: " + saltoActual);

        }
        
    }

    public void Saltar()
    {
        if (saltoActual <= saltoMax ){
            _rb.AddForce(Vector3.up * velocidadSaltoInicial);
            enSuelo = false;
            saltoActual += 1;
            Debug.Log("Usando la función de salto");
        }
        
        
    }
}
