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
    protected Rigidbody2D rb;
    // Rigidbody2D do Player
    protected LayerMask lm;
    // Layer do chão
    protected Collider2D cd;
    // Collider2D do Player
    protected virtual void Awake() 
    {
        // Atribui as três ultimas variáveis a componentes / Layers
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();
        lm = LayerMask.GetMask("Ground");
    }
    protected virtual void FixedUpdate() 
    {
        // chama o Moving()
        Moving();
    }
    protected void Moving()
    {
        if (right)
        {
            // entra caso o input recebido seja "d"
            if (direction.x < 0) 
            {
                // entra caso o Player tenha alguma força restante por ter ido para a direção oposta
                rb.velocity = new Vector2(0f, rb.velocity.y);
                // anula a força
                rb.angularVelocity = 0f;
                // anula a rotação
            }
        // atrubiu um valor à direção tanto para fazer a ação interior quanto para diminuir o tamanho dos números
        direction = new Vector2(100f, 0f);
        rb.AddForce(direction * velocity);
        right = false;
        if(Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            rb.angularVelocity = 0f;
        }
        // cancela o bool do input
        }
        else
        {
            // cancela as forças caso o input seja nulo
            if(rb.IsTouchingLayers(lm))
            {
            rb.WakeUp();
            }
            rb.velocity = new Vector2(0f, rb.velocity.y);
            rb.angularVelocity = 0f;
        }

        if (left)
        {
            // entra caso o input recebido seja "a"
            if (direction.x > 0) 
            {
                // entra caso o Player tenha alguma força restante por ter ido para a direção oposta
                rb.velocity = new Vector2(0f, rb.velocity.y);
                // anula a força
                rb.angularVelocity = 0f;
                // anula a rotação
            }
        // atrubiu um valor à direção tanto para fazer a ação interior quanto para diminuir o tamanho dos números
        direction = new Vector2(-100f, 0f);
        rb.AddForce(direction * velocity);
        left = false;
        // cancela o bool do input
        }else
        {
            // cancela as forças caso o input seja nulo
            if(rb.IsTouchingLayers(lm))
            {
            rb.WakeUp();
            }
            rb.velocity = new Vector2(0f, rb.velocity.y);
            rb.angularVelocity = 0f;
        }

        if (jump && cd.IsTouchingLayers(lm))
        {
            // entra caso o input seja "space" e o Player esteja tocando o chão
            rb.AddForce(Vector2.up * jumpForce * 100);
            jump = false;
        }
        else 
        jump = false;
        // cancela o bool do input
    }
    
}
