using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [SerializeField]
    protected float velocity = 10;
    [SerializeField]
    protected float jumpForce = 12;
    // Floats destinados a serem mudados no unity
    protected bool right, left, jump;
    // bools de direção que serão true pelo Update do Player()
    protected Vector2 direction;
    // Esse vector serve somente para cancelarmos as forças restantes quando mudamos a direção,ou seja, para o movimento ser fluído
    protected Rigidbody2D playerRigidbody;
    // Rigidbody2D do Player
    protected LayerMask lm;
    // Layer do chão
    protected Collider2D cd;
    // Collider2D do Player

    protected virtual void Awake() 
    {
        // Atribui as três ultimas variáveis a componentes / Layers
        playerRigidbody = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();
        lm = LayerMask.GetMask("Ground");
    }
    protected virtual void FixedUpdate() 
    {
        Moving();
    }
    protected void CancelLingeringForce(float f)
    {
        if(f < 0)
        {
            playerRigidbody.velocity = new Vector2(0f, playerRigidbody.velocity.y);
            playerRigidbody.angularVelocity = 0f;
        }else
        {
            playerRigidbody.velocity = new Vector2(0f, playerRigidbody.velocity.y);
            playerRigidbody.angularVelocity = 0f;
        }
    }
    protected void MoveToDirection(float f)
    {
        if(f > 0)
        {
            playerRigidbody.AddForce(direction * velocity);
            right = false;
        }
        else if(f < 0)
        {
            playerRigidbody.AddForce(direction * velocity);
            left = false;
        }
    }
    
    protected void MoveAxis()
    {
        if (right)
        {
            CancelLingeringForce(direction.x);
            direction = new Vector2(100f, 0f);
            MoveToDirection(direction.x);
        }
        else if (left)
        {
            CancelLingeringForce(direction.x);
            direction = new Vector2(-100f, 0f);
            MoveToDirection(direction.x);
        }else
        {
            playerRigidbody.velocity = new Vector2(0f, playerRigidbody.velocity.y);
            playerRigidbody.angularVelocity = 0f;
        }
    }
    protected void Moving()
    {
        MoveAxis();
        //MoveUp();
    }
    // protected void MoveUp()
    // {
    //     RaycastHit2D hit2D = CastJumpRay2D(true);
    //     if(hit2D)
    //     {
    //         if(Input.GetKey(KeyCode.F) && GetComponent<Rigidbody2D>().IsTouchingLayers(LayerMask.GetMask("Ground")))
    //         {
    //             // playerRigidbody.AddForce(Vector2.up * jumpForce * 50);
    //             stoppedJumping = false;
    //             jump = false;
    //         }

    //     }else
    //     {
    //         Debug.Log("nada");
    //     }

    //     // if (jump && cd.IsTouchingLayers(lm))
    //     // {
    //     //     // entra caso o input seja "space" e o Player esteja tocando o chão
    //     // }
    //     // else
    //     // {
    //     //     jump = false;
    //     //     // cancela o bool do input
    //     // }
    // }
    protected RaycastHit2D CastJumpRay2D(bool a=false)
    {
        Vector2 rayStartPosition = new Vector2(transform.position.x,transform.position.y - 1.2f);
        float rayLenght = .3f;
        Color rayColor = Color.red;
        //vetor funciona melhor pra cima n sei pq
        RaycastHit2D hit2D = Physics2D.Raycast(rayStartPosition,Vector2.up,rayLenght);
        
        // if bool a == true, draw a debug ray 
        if(a != false)
        {
            Debug.DrawRay(rayStartPosition,Vector2.up * rayLenght,rayColor);
        }
        return hit2D;
    }
}
