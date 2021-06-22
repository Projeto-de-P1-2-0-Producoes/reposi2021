using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private GameObject enemy;
    private float vida = 1;
    private bool auxbool = false;
    [SerializeField]
    private float movVelocity;
    [SerializeField]
    private float linearVelocity = 2;
    private Rigidbody2D enemyRb;
    private void Start() 
    {
        enemy = this.gameObject;
        enemyRb = this.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
       Moving();
       ChangeVelocity();
       GameOver();
    }
    private void Moving()
    {
        enemy.transform.position += new Vector3(0,movVelocity * Time.deltaTime * 10,0);
        if (enemy.transform.position.y <= -3.5f || enemy.transform.position.y >= 3.5f)
        {
            movVelocity *= -1;
        }
        enemyRb.AddRelativeForce(Vector3.right * linearVelocity * -10);
    }

    private void ChangeVelocity()
    {
        if(!auxbool)
        {
            StartCoroutine(ChangeDelay());
            movVelocity *= 3;
            auxbool = true;
        }
    }
    private IEnumerator ChangeDelay()
    {
        yield return new WaitForSeconds(3);
        auxbool = false;
    }
    private void GameOver()
    {
        if(vida < 1)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Player.vida -= 1;
        }   
    }
}
