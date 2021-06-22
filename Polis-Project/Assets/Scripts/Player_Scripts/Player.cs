using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Player : Movement
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    //confia
    protected override void Awake() 
    {
        // Chama o awake() do Movement
        base.Awake();
    }
    private void Update()
    {
        /*
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Rotate(Vector3(0, 180, 0));
        }
        else
        {
            transform.Rotate(Vector3(0, 0, 0));
        }
        // Anima��o andando
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("taCorrendo", true);
        }
        else 
        {
            animator.SetBool("taCorrendo", false);
        }
        */
        

        // Chama o GettingInputs()
        EndInput();  
        GettingInputs();
    }
    protected override void FixedUpdate()
    {
        // Chama o FixedUpdate() do Movement
        base.FixedUpdate();
    }

    private void GettingInputs()
    {
        // Ativa um bool para cada Input recebido
        if(Input.GetKeyDown(KeyCode.Space))
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
        if(Input.GetAxis("Horizontal") < 0)
        {
            animator.SetBool("Idleing", false);
            left = true;
            animator.SetFloat("Direction", -1);
        }
        if(Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("Idleing", true);
        }
    }
    private void EndInput()
    {
        if(right)
        {
            right = false;
        }
        if(left)
        {
            right = false;
        }
    }
}

