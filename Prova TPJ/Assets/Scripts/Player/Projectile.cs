using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform projectTransform;
    private Rigidbody2D projectileRb;
    [SerializeField]
    private float velocity = 3;
    void Start()
    {
        projectileRb = this.GetComponent<Rigidbody2D>();
        projectTransform = this.GetComponent<Transform>();
    }
    void Update()
    {
        MoveProjectile();
    }
    public void MoveProjectile()
    {
        projectileRb.AddRelativeForce(Vector3.right * velocity * 10);
        if(projectTransform.position.x > 20)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Projectile")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
