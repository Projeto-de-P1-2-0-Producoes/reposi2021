using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Player : Movement
{
    protected override void Awake() 
    {
        base.Awake();
    }
    private void Update()
    {
        GettingInputs();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    void GettingInputs()
    {
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

