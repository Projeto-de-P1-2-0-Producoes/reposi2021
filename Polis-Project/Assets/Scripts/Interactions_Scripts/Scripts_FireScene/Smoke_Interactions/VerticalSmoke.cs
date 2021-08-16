using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalSmoke : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float delay = 5;
    private bool isSmokeActive;
    private Collider2D smokeCollider;
    private SpriteRenderer testRenderer;
    private void Start()
    {
        // Animator
        smokeCollider = GetComponent<Collider2D>();
        testRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        ActiveManeger();
    }
    private void ActiveManeger()
    {
        if(isSmokeActive)
        {
            smokeCollider.enabled = false;
            testRenderer.color = Color.blue;
            StartCoroutine(ReapearDelay(delay));
            //animation
        }else
        {
            smokeCollider.enabled = true;
            testRenderer.color = Color.gray;
            StartCoroutine(ActiveDuration(delay));
            //animation
        }
    }
    private IEnumerator ReapearDelay(float f)
    {
        yield return new WaitForSeconds(f);
        isSmokeActive = false;
    }
    private IEnumerator ActiveDuration(float f)
    {
        yield return new WaitForSeconds(f);
        isSmokeActive = true;
    }
}
