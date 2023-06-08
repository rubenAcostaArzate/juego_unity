using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovSalto : MonoBehaviour
{
    public float gravedad = 1;
    public float fuerzaSalto = 1;
    public float velocidad;
    public Transform deteccionSuelo;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(Salta());
        }

        if(Input.GetKey(KeyCode.A)){
            transform.position-=velocidad*Time.deltaTime * Vector3.right;
        }else if (Input.GetKey(KeyCode.D)){
            transform.position+= velocidad * Time.deltaTime * Vector3.right;
        }
    }

    public IEnumerator Salta() {
        float impulsoActual = fuerzaSalto;
        while (impulsoActual>0) {
            transform.position += impulsoActual * Time.deltaTime * Vector3.up;
            impulsoActual -= gravedad * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        while (!Physics2D.CircleCast(deteccionSuelo.position,0.1f,Vector2.zero)) {
            transform.position += impulsoActual * Time.deltaTime * Vector3.up;
            impulsoActual -= gravedad * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
