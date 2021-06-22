using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Projectile : MonoBehaviour
{
    private Rigidbody2D projectileRb;
    private GameObject player;

    [SerializeField]
    private float velocity = 3;
    void Start()
    {
        projectileRb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        MoveProjectile();
    }
    public void MoveProjectile()
    {
        projectileRb.AddRelativeForce(Vector3.right * velocity * -10);
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
