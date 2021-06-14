using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InterativeCollision_Object : MonoBehaviour
{
    // Esse abstract é para ser usado quando o objeto tenha que fazer uma certa ação depois de ser tocado 
    protected Transform childPosition;
    // esse transform é destinaddo ao objeto que terá sua posição mudada / outra ação relacionada ao transform
    [SerializeField]
    protected string childName;
    // nome do objeto do transform acima
    // será empregado por um método mais adiante
    protected bool auxBool;
    // bool auxiliar para diferenciar a primeira ddad segunda ação
    protected abstract void FirstAction();
    // método que terá dentro a primeira ação a ser feita
    protected abstract void SecondAction();
    // método que terá dentro a segunda ação a ser feita
    protected virtual void Start()
    {
        // Defina o String serializado primeiro
        childPosition = GameObject.Find(childName).GetComponent<Transform>();
        auxBool = true;
    }
    protected void OnCollisionEnter2D(Collision2D other) 
    // quando o Player tocar o objeto 
    {
         if(other.gameObject.tag == "Player")
        {  
            FirstAction();
            auxBool = false;
        }
    }
    protected void OnCollisionExit2D(Collision2D other) 
    // quanddo o Player deixar de tocar o objeto
    {
        if(other.gameObject.tag == "Player" && !auxBool)
        {
            SecondAction();
            auxBool = false;
        }
    }
}
