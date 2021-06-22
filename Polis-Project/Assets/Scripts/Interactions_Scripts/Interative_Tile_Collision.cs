using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interative_Tile_Collision : MonoBehaviour
{
    private Collider2D plataformCollider;
    private bool entered;
    private bool disappearDone;
    private bool appearDone;
    private Animator[] animator;
    [SerializeField]
    private float disappearDelayF = 3;
    [SerializeField]
    private float appearDelayF = 3;
    private void Awake() 
    {
        plataformCollider = GetComponent<Collider2D>();
        animator = GetComponentsInChildren<Animator>();
    }
    private void Update() 
    {
        /*
        if(entered)
        {
            StartCoroutine(DisappearDelay());
            if(disappearDone)
            {
                Disappear();
                disappearDone = false;
                StartCoroutine(AppearDelay());
            }
        }
        if(appearDone)
        {
            Appear();
            appearDone = false;
        }
        */
        if(disappearDone)
        {
            StartCoroutine(AppearDelay());
        }
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(DisappearDelay());
        }
    }
    private void Disappear()
    {
        plataformCollider.enabled = false;
    }
    private IEnumerator DisappearDelay()
    {
        foreach(Animator animators in animator)
        {
            animators.SetBool("touched",true);
        }
        yield return new WaitForSeconds(disappearDelayF);
        Disappear();
        disappearDone = true;
    }
    private void Appear()
    {
        plataformCollider.enabled = true;
        foreach(Animator animators in animator)
        {
            animators.SetBool("touched",false);
        }
    } 
    private IEnumerator AppearDelay()
    {
        disappearDone = false;
        yield return new WaitForSeconds(appearDelayF);
        Appear();
        //appearDone = true;
    }
}
