using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Scene : MonoBehaviour
{
    private Transform camTransform;
    public BoolVariable playerHoldingStone;
    public BoolVariable firstActionDone;
    private Transform playerTransform;
    [SerializeField]
    private float playerPositionAdjustment;
    [SerializeField]
    private float ajdustObjPosition = 33;
    [SerializeField]
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        camTransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        // Atribui todos os componentes como citado acima
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            playerTransform.position = new Vector3(playerTransform.position.x + playerPositionAdjustment,-4.774964f,playerTransform.position.z);
            // muda a posição do jogador
            camTransform.position = new Vector3(camTransform.position.x + ajdustObjPosition,camTransform.position.y,camTransform.position.z);
            // Muda a posição da camera exatamente para a direita
            firstActionDone.value = false;
            playerHoldingStone.value = false;
        }    
    }
}
