using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Interative_Brige : InterativeTriggering_Object
{
    protected override void Start() 
    {
        ChildName("Plata1");
        base.Start();
    }
    protected override void Update() 
    {
        base.Update();    
    }
    protected override void FirstAction()
    {
        childPosition.position = auxPosition;
        childPosition.Rotate(0,0,-90);
    }
    protected override void SecondAction()
    {
        childPosition.Rotate(0,0,90);
        childPosition.position = new Vector3(-2.55f,-2.45f,childPosition.position.z);
    }
}
