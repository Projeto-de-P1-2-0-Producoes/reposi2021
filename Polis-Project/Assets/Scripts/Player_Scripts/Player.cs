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
        GettingInputs();
    }
    protected override void FixedUpdate()
    {
        // Chama o FixedUpdate() do Movement
        base.FixedUpdate();
    }

    void GettingInputs()
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
    }
}

