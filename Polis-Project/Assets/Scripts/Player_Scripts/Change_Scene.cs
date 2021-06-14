using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Scene : MonoBehaviour
{
    private Transform camPosition;
    // Pega o Transform da camera
    [SerializeField]
    private float ajdustObjPosition = 33;
    [SerializeField]
    private float adjustThisObjectMovBack = 1.2f;
    private BoxCollider2D bc;
    // Pega o BoxCollider2D do objeto que usamos para mudar de cena
    private Transform thisTransform;
    //Pega o tranforme do objeto que usamos para mudar de cena
    void Start()
    {
        camPosition = GameObject.Find("Main Camera").GetComponent<Transform>();
        thisTransform = GetComponent<Transform>();
        bc = GetComponent<BoxCollider2D>();
        // Atribui todos os componentes como citado acima
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            camPosition.position = new Vector3(camPosition.position.x + ajdustObjPosition,camPosition.position.y,camPosition.position.z);
            // Muda a posição da camera exatamente para a direita
            thisTransform.position = new Vector3(thisTransform.position.x - adjustThisObjectMovBack ,thisTransform.position.y,thisTransform.position.z);
            // Muda a posição do objeto que usamos de mudança de cena para exatamente esquerda da camera
            bc.isTrigger = false;
            // Desliga o trigger para que o player não consiga voltar 
        }    
    }
}
