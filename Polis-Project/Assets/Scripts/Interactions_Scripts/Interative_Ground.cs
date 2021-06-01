using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interative_Ground : MonoBehaviour
{
    private BoxCollider2D obj_Collider;
    private SpriteRenderer obj_Sprite;
    private GameObject player;
    private bool isEnabled;
    private bool auxBool;
    private bool auxBool1;
    private bool auxBool2;
    private bool IsRunning;
    private void Start()
    {
        player = GameObject.Find("Player");
        obj_Sprite = GetComponent<SpriteRenderer>();
        obj_Collider = GetComponent<BoxCollider2D>();
    }
    private void Update() 
    {
        if(auxBool1)
        {
            StartCoroutine(FirstAction());
            StopCoroutine(FirstAction());
            auxBool1 = false;
        }
        if(auxBool2 && !IsRunning)
        {
            StartCoroutine(SecondAction());
            StopCoroutine(SecondAction());
            auxBool2 = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            auxBool1 = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            auxBool2 = true;
        }
      
    }
    private IEnumerator FirstAction()
    {
        IsRunning = true;
        obj_Sprite.color = Color.yellow;
        if(!auxBool)
        {
            yield return new WaitForSeconds(3); 
            obj_Collider.enabled = false;
            auxBool = true;
        }
        IsRunning = false;
    }
    private IEnumerator SecondAction()
    {
        if(auxBool)
        {
            yield return new WaitForSeconds(3); 
            obj_Collider.enabled = true;
            obj_Sprite.color = Color.blue;
            auxBool = false;
        }
    }
    
}

