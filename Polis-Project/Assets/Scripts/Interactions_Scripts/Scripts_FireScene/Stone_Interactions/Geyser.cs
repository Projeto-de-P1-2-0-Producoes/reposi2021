using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geyser : MonoBehaviour
{
    private float gravityScale;
    private Transform playerTransform;
    private Rigidbody2D playerRigidbody;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        gravityScale = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().gravityScale;
    }
    private void ActivateGeyser()
    {
        playerRigidbody.gravityScale = 0;
        playerTransform.Translate(Vector3.up * .25f, Space.World);
        if(playerTransform.position.y >= 0.5f)
        {
            playerTransform.Translate(0,0,0);
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        playerRigidbody.gravityScale = gravityScale;
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            ActivateGeyser();
        }
    }
}
