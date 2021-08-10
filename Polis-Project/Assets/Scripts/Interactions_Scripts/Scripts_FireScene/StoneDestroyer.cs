using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private List<GameObject> stonesList = new List<GameObject>();
    private List<Vector3> stonesTransformVector3List = new List<Vector3>();
    private int StoneCollisionIndex;
    public BoolVariable firstInteractionDone;
    private void Start() 
    {
        foreach(GameObject stone in stonesList)
        {
            stonesTransformVector3List.Add(stone.transform.position);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.transform.CompareTag("Player"))
        {
            GetStoneIndex();
            ReturnOriginalPosition();
            firstInteractionDone.value = false;
        }    
    }
    private void GetStoneIndex()
    {
        foreach(GameObject stone in stonesList)
        {
            if(!stone.activeSelf)
            {
                StoneCollisionIndex = stonesList.IndexOf(stone);
            }
        }
    }
    private void ReturnOriginalPosition()
    {
        stonesList[StoneCollisionIndex].SetActive(true); 
        stonesList[StoneCollisionIndex].gameObject.transform.position = new Vector3(stonesTransformVector3List[StoneCollisionIndex].x,stonesTransformVector3List[StoneCollisionIndex].y,stonesTransformVector3List[StoneCollisionIndex].z);
    }
}
