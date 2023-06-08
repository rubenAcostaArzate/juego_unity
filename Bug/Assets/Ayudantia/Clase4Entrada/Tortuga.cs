using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tortuga : MonoBehaviour {

    public float velocidad;

    public Sprite spritedañado;

    private Animator animator;

    public Transform pipa;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator= GetComponent<Animator>();
        //animator.SetInteger("vida",0);
    }

    private void FixedUpdate(){
        Rigidbody2D rb= GetComponent<Rigidbody2D>();
        rb.velocity=new Vector2(-velocidad,rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D col){
     if(col.CompareTag("muro invisible")){
       velocidad *=-1;
       spriteRenderer.flipX= !spriteRenderer.flipX;
     }
    }

    private void Update(){
     /* RaycastHit2D rayhit=Physics2D.Raycast(pipa.position, Vector2.down,1f);
      if (!rayhit){

      }*/
    }
}
