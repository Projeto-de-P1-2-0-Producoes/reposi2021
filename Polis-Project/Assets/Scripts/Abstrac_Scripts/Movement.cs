using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [SerializeField]
    protected float velocity, jumpForce;
    protected bool right, left, back, forward, jump;
    protected Vector2 direction;
    protected Rigidbody2D rb;
    protected LayerMask lm;
    protected CircleCollider2D cd;
    protected virtual void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<CircleCollider2D>();
        lm = LayerMask.GetMask("Ground");    
    }
    protected virtual void FixedUpdate() 
    {
        Moving();    
    }
    protected void Moving()
    {
        if (right)
        {
            if (direction.x < 0) 
            {
                rb.velocity = new Vector2(0f, rb.velocity.y);
                rb.angularVelocity = 0f;
            }
            direction = new Vector2(100f, 0f);
            rb.AddForce(direction * velocity);
            right = false;
        }else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            rb.angularVelocity = 0f;
        }

        if (left)
        {
            if (direction.x > 0) 
            {
                rb.velocity = new Vector2(0f, rb.velocity.y);
                rb.angularVelocity = 0f;
            }
            direction = new Vector2(-100f, 0f);
            rb.AddForce(direction * velocity);
            left = false;
        }else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            rb.angularVelocity = 0f;
        }

        if (jump && cd.IsTouchingLayers(lm))
        {
            rb.AddForce(Vector2.up * jumpForce * 100);
            jump = false;
        }
        else 
        jump = false;

    }
    
}
