using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneda : MonoBehaviour
{
 public GameObject monedas;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    private void OnTriggerEnter2D(Collider2D col){
      if(col.gameObject.CompareTag("Mario")){
        Destroy(monedas);
      }  
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
