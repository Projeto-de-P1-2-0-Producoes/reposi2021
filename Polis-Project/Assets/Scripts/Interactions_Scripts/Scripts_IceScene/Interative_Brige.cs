using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Interative_Brige : InterativeTriggering_Object
{
    protected override void Start() 
    {
        base.Start();
    }
    protected override void Update() 
    {
        base.Update();    
    }
    protected override void FirstAction()
    {
        childTransform.Rotate(0,0,-90);
    }
    protected override void SecondAction()
    {
        childTransform.Rotate(0,0,90);
    }
}
