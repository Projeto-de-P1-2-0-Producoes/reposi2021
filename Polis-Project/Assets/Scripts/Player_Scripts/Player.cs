using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Player : Movement
{
    private Animator animator;
    private GameObject lastGameObject; 
    public BoolVariable stoneInteraction;
    public BoolVariable firstInteractionDone;
    private Vector2 castRayDirection;
    private void Start()
    {
        animator = GetComponent<Animator>();
        firstInteractionDone.value = false;
    }
    protected override void Awake() 
    {
        base.Awake();
    }
    private void Update()
    {
        GettingInputs();
        InteractionManeger(Input.GetKeyDown(KeyCode.F),true);
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    private void GettingInputs()
    {
        // Ativa um bool para cada Input recebido
        if(Input.GetKey(KeyCode.Space))
        {
            jump = true;
        }
        // Ativa um bool para o input das setas
        if(Input.GetAxis("Horizontal") > 0)
        {
            animator.SetBool("Idleing", false);
            right = true;
            animator.SetFloat("Direction", 1);
            
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            animator.SetBool("Idleing", false);
            left = true;
            animator.SetFloat("Direction", -1);
            
        }
        else
        {
            animator.SetBool("Idleing", true);
        }
    }
    private void InteractionManeger(bool input, bool debug = false)
    {
        CastRay2D(debug);
        if(input)
        {
            if(!firstInteractionDone.value)
            {
                FirstAction();
            }else
            {
                SecondAction();
            }
        }
    }
    private void FirstAction()
    {
        RaycastHit2D hit2D = CastRay2D();
        if(hit2D)
        {
            if(hit2D.transform.CompareTag("Stone") && GetComponent<Rigidbody2D>().IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                lastGameObject = hit2D.collider.gameObject;
                hit2D.collider.gameObject.SetActive(false);
                firstInteractionDone.value = true;
                stoneInteraction.value = true;
            }
        }
    }
    private void SecondAction()
    {
        //raycasthit2d here is for future interactions that might need it
        RaycastHit2D hit2D = CastRay2D(); 
        if(stoneInteraction.value && lastGameObject != null && GetComponent<Rigidbody2D>().IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            if(castRayDirection.x > 0)
            {
                lastGameObject.transform.position = (Vector2)transform.position + new Vector2(1.5f,-0.45f);
                lastGameObject.SetActive(true);
            }else
            {
                lastGameObject.transform.position = (Vector2)transform.position + new Vector2(-1.5f,-0.45f);
                lastGameObject.SetActive(true);
            }
            lastGameObject = null;
            stoneInteraction.value = false;
            firstInteractionDone.value = false;
        }
    }
    private RaycastHit2D CastRay2D(bool a=false)
    {
        Vector2 rayStartPosition = GetRayStartPosition();
        float rayLenght = 1;
        Color rayColor = Color.red;
        RaycastHit2D hit2D = Physics2D.Raycast(rayStartPosition,castRayDirection,rayLenght);
        
        // if bool a == true, draw a debug ray 
        if(a != false)
        {
            Debug.DrawRay(rayStartPosition,castRayDirection * 1,rayColor);
        }
        return hit2D;
    }
    private Vector2 GetRayStartPosition()
    {
        //  also inicialize the direction of the Raycasthit2d
        if(direction.x >= 0)
        {
            castRayDirection = Vector2.right;
            return (Vector2)transform.position + new Vector2(0.14f * (transform.localScale.x), -.4f);
        }
        else
        {
            castRayDirection = Vector2.left;
            return (Vector2)transform.position + new Vector2(-0.14f * (transform.localScale.x), -.4f);
        }
    }
}