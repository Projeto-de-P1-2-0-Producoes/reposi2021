using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interative_PressurePlate : InterativeCollision_Object
{
    [SerializeField]
    private float distance;
    private Transform playerTransform;
    private Rigidbody2D playerRB;
    protected override void Start()
    {
        base.Start();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        playerRB = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }
    protected override void FirstAction()
    {
        childPosition.position = new Vector3 (childPosition.position.x + distance,childPosition.position.y,childPosition.position.z); 
        playerTransform.position = new Vector3 (playerTransform.position.x + distance,playerTransform.position.y,playerTransform.position.z);
        playerRB.velocity = new Vector3(0f,0f,0f);
        playerRB.angularVelocity = 0f;
    }

    protected override void SecondAction()
    {
        Delay();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
    }
}
