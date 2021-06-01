using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InterativeCollision_Object : MonoBehaviour
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
        auxBool = true;
    }
    protected void OnCollisionStay2D(Collision other) 
    {
        if(other.gameObject.tag == "Player" && auxBool)
        {
            Debug.Log("aaa");
            FirstAction();
            auxBool = false;
        }else if(other.gameObject.tag == "Player")
        {
            SecondAction();
            auxBool = false;
        }
    }
}
