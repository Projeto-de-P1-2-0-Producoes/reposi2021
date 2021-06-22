using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject enemy;
    private float vida = 1;
    private bool auxbool = false;
    [SerializeField]
    private float movVelocity;
    [SerializeField]
    private GameObject projectile;
    private Rigidbody2D enemyRb;
    [SerializeField]
    private float shottingDelay = 1.5f;
    private void Start() 
    {
        enemy = this.gameObject;
        enemyRb = this.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
       Moving();
       Shotting();
       GameOver();
    }
    private void Moving()
    {
        enemy.transform.position += new Vector3(0,movVelocity * Time.deltaTime * 10,0);
        if (enemy.transform.position.y <= -3.5f || enemy.transform.position.y >= 3.5f)
        {
            movVelocity *= -1;
        }
    }

    private void Shotting()
    {
        if(Random.Range(0f,10f) > 5)
        {   
            if(!auxbool)
            {
                Instantiate(projectile, new Vector3(enemy.transform.position.x + 5, enemy.transform.position.y, enemy.transform.position.z),Quaternion.identity);
                StartCoroutine(BulletDelay());
                auxbool = true;
            }
        }
    }
    private IEnumerator BulletDelay()
    {
        yield return new WaitForSeconds(shottingDelay);
        auxbool = false;
    }
    private void GameOver()
    {
        if(vida < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
