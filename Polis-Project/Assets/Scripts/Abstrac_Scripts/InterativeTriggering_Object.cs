using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InterativeTriggering_Object : MonoBehaviour
{
    protected Transform childPosition;
    protected string childName;
    protected Vector3 auxPosition;    
    protected bool auxBool;

    protected abstract void FirstAction();
    protected abstract void SecondAction();
    protected void ChildName(string child)
    {
        childName = child;
    }
    protected virtual void Start()
    {
        childPosition = GameObject.Find(childName).GetComponent<Transform>();
        auxPosition = childPosition.position;
        auxBool = false;
    }
    protected virtual void Update() 
    {
        GetInput();    
    }
    protected void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player" && auxBool && auxPosition != childPosition.position)
        {
            FirstAction();
            auxBool = false; 
        }else if(other.gameObject.tag == "Player" && auxBool)
        {
            SecondAction();
            auxBool = false; 
        }
    }
    protected void GetInput()
    {
        if(Input.GetKeyDown(KeyCode.F))
            auxBool = true;
    }
}
