using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour
{
    [Header("Jump Details")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpTime;
    private float jumpTimeCounter;
    private bool stoppedJumping;
    
    [Header("GroundDetails")]
    private bool grounded;

    [Header("Components")]
    private Rigidbody2D playerRigidbody;

    private void Start() 
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        jumpTimeCounter = jumpTime;
    }
    private void Update() 
    {
        // grounded = Physics2D.OverlapCircle(groundCheck.position,radOCircle,whatIsGround);
        RaycastHit2D hit2d = CastJumpRay2D(true);
        if(hit2d)
        {
            if(hit2d.transform.CompareTag("Ground"))
            {
                grounded = true;
            }
            else
            {
                grounded = false;
            }
        }
        else 
        {
            grounded = false;
        }
        if(grounded)
        {
            jumpTimeCounter = jumpTime;
        }

        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
            stoppedJumping = false;
        }    

        if(Input.GetKey(KeyCode.Space) && !stoppedJumping && (jumpTimeCounter > 0))
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
            jumpTimeCounter -= Time.deltaTime;
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }

    }
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
