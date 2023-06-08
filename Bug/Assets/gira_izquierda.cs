using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gira_izquierda : MonoBehaviour
{
    public SpriteRenderer tortuga;
    // Start is called before the first frame update
    void Start()
    {
        tortuga=GetComponent<SpriteRenderer>();
    }

    public void OnCollisionEnter(Collision collision){
        tortuga.flipX=true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
