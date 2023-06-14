using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma_rompible : MonoBehaviour
{
    public GameObject plataforma;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("Player")){
           Invoke("destruir",3);
        }
    }

    public void destruir(){
      Destroy(plataforma);
    }
}
