using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Player : MonoBehaviour
{
    private GameObject player;
    private float direcaox;
    public static float vida = 5;
    private float direcaoy;
    private bool auxbool = false;
    [SerializeField]
    private GameObject enemy1;
    [SerializeField]
    private GameObject enemy2;
    private bool GenerateBool;
    [SerializeField]
    private float GenerationDelay = 3;
    private bool attack = false;
    [SerializeField]
    private float velocity = 1;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float shottingDelay = 0.5f;
    private void Start() 
    {
        player = this.gameObject;
    }
    private void Update()
    {
        GettingInputs();
    }
    private void FixedUpdate()
    {
       Moving();
       Shotting();
       GameOver();
       GenerateEnemies();
    }
    private void Moving()
    {
        player.transform.position = new Vector3(player.transform.position.x + direcaox * Time.deltaTime,player.transform.position.y + direcaoy * Time.deltaTime, player.transform.position.z);
    }

    private void Shotting()
    {
        if(attack && !auxbool)
        {
            Instantiate(projectile, new Vector3(player.transform.position.x + 5, player.transform.position.y, player.transform.position.z),Quaternion.identity);
            StartCoroutine(BulletDelay());
            auxbool = true;
        }
    }
    private IEnumerator BulletDelay()
    {
        yield return new WaitForSeconds(shottingDelay);
        auxbool = false;
    }
    private void GettingInputs()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            direcaox = 1 * velocity;
        }
        if(Input.GetAxis("Horizontal") < 0)
        {
            direcaox = -1 * velocity;
        }
        if(Input.GetAxis("Horizontal") == 0)
        {
            direcaox = 0 * velocity;
        }
        if(Input.GetAxis("Vertical") > 0)
        {
            direcaoy = 1 * velocity;
        }
        if(Input.GetAxis("Vertical") < 0)
        {
            direcaoy = - 1 * velocity;
        }
        if(Input.GetAxis("Vertical") == 0)
        {
            direcaoy = 0 * velocity;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            attack = true;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            attack = false;
        }
    }
    private void GameOver()
    {
        if(vida < 1)
        {
            Destroy(this.gameObject);
        }
    }
    private void GenerateEnemies()
    { 
        if(!GenerateBool)
        {
            if(Random.Range(0f,1f) > 0.5f )
            {
                StartCoroutine(GenerateDelay());
                Instantiate(enemy1, new Vector3(7, Random.Range(-3.5f,3.5f), player.transform.position.z),Quaternion.identity);
                GenerateBool = true;
            }else
            {
                StartCoroutine(GenerateDelay());
                Instantiate(enemy2, new Vector3(7, Random.Range(-3.5f,3.5f), player.transform.position.z),Quaternion.identity);
                GenerateBool = true;
            }
        }
    }
    private IEnumerator GenerateDelay()
    {
        yield return new WaitForSeconds(GenerationDelay);
        GenerateBool = false;
    }
}

