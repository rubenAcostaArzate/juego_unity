using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_up : MonoBehaviour
{
    private SpriteRenderer sprite;

    public GameObject power;
    // Start is called before the first frame update
    void Start()
    {
       sprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("Player")){
          sprite.enabled=false;
          Destroy(power);
        }


    }
}
