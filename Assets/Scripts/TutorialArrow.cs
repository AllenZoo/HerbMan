using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialArrow : MonoBehaviour
{
    private SpriteRenderer sprite;
    private bool isFlashing;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        isFlashing = false;
    }
    private void Start()
    {
        
    }

    public void StartFlashing()
    {
        isFlashing = true;
        StartCoroutine(Flash());
    }
    public void StopFlashing()
    {
        isFlashing = false;
    }

    private IEnumerator Flash()
    {
        while (isFlashing)
        {
            yield return new WaitForSeconds(1/10);
        }
    }
}
