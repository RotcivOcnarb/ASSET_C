using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    Animator animator;
    Rigidbody2D body;

    public float MAX_SPEED = 3;
    public float feetPosition;
    public float jumpStrength = 10;
    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    //Movimentação

        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -feetPosition), -Vector3.up, 0.5f);
        float hor = Input.GetAxisRaw("Horizontal");

        //Movimenta o player
        if(!GlobalVars.inputBlocked){
            body.AddForce(new Vector2(hor, 0) * 100);
        
            //Clampa a velocidade pra não passar do máximo
            if((body.velocity * new Vector2(1, 0)).magnitude > MAX_SPEED){
                if(body.velocity.x < 0) body.velocity = new Vector2(-MAX_SPEED, body.velocity.y);
                if(body.velocity.x > 0) body.velocity = new Vector2(MAX_SPEED, body.velocity.y);
            }

            //Freia o player se não tiver pressionando nenhuma tecla
            if(hor == 0)
                body.velocity = new Vector2(body.velocity.x * .8f, body.velocity.y);
            
            //Faz o player pular
            if(Input.GetKeyDown(KeyCode.W) && hit){
                body.velocity = new Vector2(body.velocity.x, jumpStrength);
            }
        }
        else{
            body.velocity = new Vector2(0, 0);
        }

        //Direcionamento do Sprite

        if(hor < 0)
            spriteRenderer.flipX = false;
        else if(hor > 0)
            spriteRenderer.flipX = true;
        
        //Controle de Animação
        animator.SetBool("Walking", hor !=  0);
        animator.SetBool("InAir", !hit);

    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position - new Vector3(.5f, feetPosition), transform.position - new Vector3(-.5f, feetPosition));
    }

}
