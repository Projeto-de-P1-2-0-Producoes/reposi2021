using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InterativeTriggering_Object : MonoBehaviour
{
    // Essa classe é para ser usada quando um objeto irá realizar uma ou duas ações após o Player entrar na área do trigger e acinar o input "f" 
    // Todos os comentários em InterativeCollision_Object valem para este
    protected Transform childTransform;
    [SerializeField]
    protected string childName;     
    protected bool inputRegister;
    protected bool firstDone = false;
    protected LayerMask lm;
    protected Rigidbody2D player;
    protected bool IsOnRadius;
    protected virtual void Start()
    {
        IsOnRadius = false;
        childTransform = GameObject.Find(childName).GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        //player.WakeUp();
        // salva a primeira posição do objeto
        lm = LayerMask.GetMask("Ground");    
        inputRegister = false;
    }
    protected virtual void Update() 
    {
        GetInput();   
        // constantemente checa os inputs 
    }
    protected void OnTriggerStay2D(Collider2D other) 
    {
        IsOnRadius = true;
        if(inputRegister && !firstDone && other.gameObject.tag == "Player" && IsOnRadius)
        {
            FirstAction();
            inputRegister = false; 
            firstDone = true;
        }
        else if(other.gameObject.tag == "Player" && inputRegister && firstDone && IsOnRadius)
        // a terceira verificação é para conferir se o objeto já foi movido
        {
            SecondAction();
            inputRegister = false; 
            firstDone = false;
        }
        
    }
    protected void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            IsOnRadius = false;
            inputRegister = false;
        }
    }
    protected void GetInput()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            inputRegister = true;
        }
    }
    protected abstract void FirstAction();
    protected abstract void SecondAction();
    // é suposta a ser a volta do objeto à sua posição original, ou seja, o oposto da primeira ação
}
