using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToFireScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            ChangeScene("Fire_Scene");
        }    
    }
    public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}
}
