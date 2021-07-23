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
        // Chama o GettingInputs()
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
}

