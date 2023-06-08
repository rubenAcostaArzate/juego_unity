using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daño_y_muerte : MonoBehaviour
{
    public int vida;

    public SpriteRenderer mario_grande;

    public SpriteRenderer mario_pequeño;
    // Start is called before the first frame update
    void Start()
    {
        vida=2;
    }

    /*public void OnCollisionEnter(Collision collision){
      if(collision.TryGetComponent(out MovVelocity velocity)){
          if(velocity.enemigo==false){
            vida=-1;
            if(vida<=0){
                //mario_pequeño.Destroy();
            }
          }
      }
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
