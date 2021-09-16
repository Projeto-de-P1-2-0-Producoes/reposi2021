using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToEarthScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            ChangeScene("Earth_Scene");
        }    
    }
    public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}
}
