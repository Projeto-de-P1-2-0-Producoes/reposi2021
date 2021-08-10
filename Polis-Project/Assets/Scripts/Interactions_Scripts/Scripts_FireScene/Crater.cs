using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crater :  MonoBehaviour
{
    private Transform stoneTransform;
    private bool geyserOn;
    private Rigidbody2D stoneRigidbody;
    [SerializeField]
    private GameObject[] geysers;
    private void Update() 
    {
        GeyserControl();
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Stone")
        {
            stoneTransform = other.gameObject.GetComponent<Transform>();
            stoneRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            PutStoneOnTop();
        }
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Stone")
        {
            TakeStoneOffTop();
        }
    }
    private void PutStoneOnTop()
    {
        //start animation "stone on crater"
        stoneRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        stoneTransform.position = new Vector3(transform.position.x,stoneTransform.position.y,stoneTransform.position.z);
        geyserOn = true;
    }
    private void TakeStoneOffTop()
    {
        //start animation "taking stone"
        stoneRigidbody.constraints = RigidbodyConstraints2D.None;
        geyserOn = false;
    }
   private void GeyserControl()
   {
       if(geyserOn)
       {
           foreach(GameObject element in geysers)
           {
               element.SetActive(true);
           }
       }
       else
       {
           foreach(GameObject element in geysers)
           {
               element.SetActive(false);
           }
       }
   }
}