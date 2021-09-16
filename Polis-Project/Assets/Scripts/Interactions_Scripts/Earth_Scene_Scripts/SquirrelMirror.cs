using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelMirror : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D playerRigidbody;
    private Rigidbody2D squirrelRigidbody;
    private Animator squirrelAnimator;
    private bool isTouchingPlayer;
    private Renderer squirrelRenderer;
    private void OnBecameInvisible() 
    {
        enabled = false;
    }
    private void OnBecameVisible() 
    {
        enabled = true;    
    }
    void Start()
    {
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        squirrelAnimator = GetComponent<Animator>();
        squirrelRigidbody = GetComponent<Rigidbody2D>();
        squirrelRenderer = GetComponent<Renderer>();
        squirrelRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        NormalizeSquirrelFalling();
        if(squirrelRenderer.isVisible)
        {
            MoveSquirrel();
        }
    }
    private void MoveSquirrel()
    {
        BlockTheWay();
        if(!isTouchingPlayer)
        {
            squirrelRigidbody.velocity = GetInvertedPlayerForces();
            if(squirrelRigidbody.velocity.magnitude > 1)
            {
                squirrelAnimator.SetBool("IsMoving",true);
            }
            else
            {
                squirrelAnimator.SetBool("IsMoving",false);
            }
        }

    }
    private void BlockTheWay()
    {
        RaycastHit2D hit2d = CastTouchingRay2D();
        if(hit2d)
        {
            if(hit2d.transform.CompareTag("Player"))
            {
                squirrelRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
                squirrelRigidbody.velocity = new Vector2 (0f, squirrelRigidbody.velocity.y);
                isTouchingPlayer = true;
                Debug.Log("tocou jogador");
            }
            else
            {
                isTouchingPlayer = false;
                squirrelRigidbody.constraints = RigidbodyConstraints2D.None;
                squirrelRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
        else
        {
            squirrelRigidbody.constraints = RigidbodyConstraints2D.None;
            squirrelRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            isTouchingPlayer = false;
        }
    }
    private Vector2 GetInvertedPlayerForces()
    {
        return new Vector2(-playerRigidbody.velocity.x, playerRigidbody.velocity.y);
    }
    private void NormalizeSquirrelFalling()
    {
        if(playerRigidbody.velocity.magnitude < 1)
        {
            RaycastHit2D hit2d = CastGroundRay2D(true);
            if(!hit2d)
            {
                squirrelRigidbody.AddForce(new Vector2 (0,-150000));
            }
        }
    }
    private RaycastHit2D CastTouchingRay2D(bool a=false)
    {
        Vector2 rayStartPosition = new Vector2(transform.position.x - .6f,transform.position.y);
        float rayLenght = .1f;
        Color rayColor = Color.red;
        RaycastHit2D hit2D = Physics2D.Raycast(rayStartPosition,Vector2.left,rayLenght);
        
        // if bool a == true, draw a debug ray 
        if(a != false)
        {
            Debug.DrawRay(rayStartPosition,Vector2.left * rayLenght,rayColor);
        }
        return hit2D;
    }
    private RaycastHit2D CastGroundRay2D(bool a=false)
    {
        Vector2 rayStartPosition = new Vector2(transform.position.x,transform.position.y -.6f);
        float rayLenght = .1f;
        Color rayColor = Color.red;
        RaycastHit2D hit2D = Physics2D.Raycast(rayStartPosition,Vector2.down,rayLenght);
        
        // if bool a == true, draw a debug ray 
        if(a != false)
        {
            Debug.DrawRay(rayStartPosition,Vector2.down * rayLenght,rayColor);
        }
        return hit2D;
    }
}
