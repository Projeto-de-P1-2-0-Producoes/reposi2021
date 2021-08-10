using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interative_Button : InterativeTriggering_Object
{
    [SerializeField]
    private Vector3 newPosition;
    private Vector3 auxPosition;
    protected override void Start()
    {
        base.Start();
        auxPosition = childTransform.position;
    }

    protected override void Update()
    {
        base.Update();
    }
    protected override void FirstAction()
    {
        childTransform.position = newPosition;
    }
    protected override void SecondAction()
    {
        childTransform.position = auxPosition;
    }
}
