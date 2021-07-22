using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoPlat : MonoBehaviour
{ float movSpd = -2;
    public Rigidbody2D nome;
    private void FixedUpdate()
    {
        nome.MovePosition(nome.position * movSpd * Time.fixedDeltaTime);
    }

   
        }
    

