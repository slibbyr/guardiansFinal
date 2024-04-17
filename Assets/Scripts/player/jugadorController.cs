using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugadorController : MonoBehaviour
{
    public int velocidad;

    private Rigidbody2D rbody;
    private BoxCollider2D boxCollider2D;
    private bool mirandoDerecha;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        procesarMovimiento();
        movimiento();
    }

    void movimiento(){
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");

        rbody.velocity = new Vector2(movHorizontal*velocidad, movVertical*velocidad);


    }

    void procesarMovimiento(){
        float inputMovimeinto = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
    
        if(Input.GetKey(KeyCode.LeftArrow)){
            animator.SetBool("isRunDer",true);
            animator.SetBool("isRunFront",false);
            animator.SetBool("isRunBack",false);
        }else if(Input.GetKey(KeyCode.RightArrow)){
            animator.SetBool("isRunDer",true);
            animator.SetBool("isRunFront",false);
            animator.SetBool("isRunBack",false);
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            animator.SetBool("isRunDer",false);
            animator.SetBool("isRunFront",false);
            animator.SetBool("isRunBack",true);
        }else if(Input.GetKey(KeyCode.DownArrow)){
            animator.SetBool("isRunDer",false);
            animator.SetBool("isRunFront",true);
            animator.SetBool("isRunBack",false);
        }
        
        rbody.velocity = new Vector2(inputMovimeinto*velocidad, rbody.velocity.y);
        gestionarOrientacion(-inputMovimeinto);
    }

    void gestionarOrientacion(float inputMovimiento){
       if ((mirandoDerecha == true && inputMovimiento < 0) || (mirandoDerecha == false && inputMovimiento > 0)){
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}