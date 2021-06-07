using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interative_Ground : InterativeCollision_Object
{
    private Collider2D groundCollider;
    private SpriteRenderer groundRender;
    // variáveis do Collider e Sprite do objeto
    [SerializeField]
    private float delayTime1 = 3;
    [SerializeField]
    private float delayTime2 = 3;
    protected override void Start()
    {
        groundCollider = GameObject.Find(childName).GetComponent<Collider2D>();
        groundRender = GameObject.Find(childName).GetComponent<SpriteRenderer>();
        base.Start();
        // o base é importante para a ordem das ações ocorrer
    }
    protected override void FirstAction()
    {
        StartCoroutine(Disappear());
        // começa a primeira coroutine
        // as rotinas não soprepôem por conta do desativamento do collider nas coroutine
    }
    protected override void SecondAction()
    {
        StartCoroutine(Appear());
        // começa a segunda coroutine
    }
    private IEnumerator Disappear()
    {
        groundRender.color = Color.black;
        yield return new WaitForSeconds(delayTime1); 
        groundCollider.enabled = false;
        /*
        muda a cor
        espera 3 segundos
        desativa o collider
        */
    }
    private IEnumerator Appear()
    {
        yield return new WaitForSeconds(delayTime2); 
        groundCollider.enabled = true;
        groundRender.color = Color.blue;
        /*
        espera 3 segundos
        ativa o collider
        muda a cor
        */
    }
}

