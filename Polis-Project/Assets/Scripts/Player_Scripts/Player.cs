using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Player : Movement
{
    protected override void Awake() 
    {
        // Chama o awake() do Movement
        base.Awake();
    }
    private void Update()
    {
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
        if(Input.GetKey(KeyCode.D))
        {
            right = true;
        }
        if(Input.GetKey(KeyCode.A))
        {
            left = true;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        // Ativa um bool para o input das setas
        if(Input.GetAxis("Horizontal") > 0)
        {
            right = true;
        }
        if(Input.GetAxis("Horizontal") < 0)
        {
            left = true;
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

