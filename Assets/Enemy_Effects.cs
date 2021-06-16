using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Effects : MonoBehaviour
{
    private SpriteRenderer myRenderer;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;
    private bool crRunning = false;

    private void Awake()
    {
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default");
    }

    private void Start()
    {
        
    }

    public void FlickerWhite()
    {
        if (!crRunning)
        {
            crRunning = true;
            StartCoroutine(FlickerWhiteIE(3));
        }
    }

    private IEnumerator FlickerWhiteIE(float amountOfFlicks)
    {
        var count = 0;
        crRunning = true;
        for(int i = 0; i  < amountOfFlicks; i++)
        {
            count = i;
            Debug.Log("Flickering white");
            FlashToWhite();
            yield return new WaitForSeconds(1/2);
            Debug.Log("Flickering to normal");
            FlashToNormal();
            yield return new WaitForSeconds(1/2);
        }
        if (count == amountOfFlicks - 1)
        {
            crRunning = false;
        }
        yield return null;
    }

    private void FlashToWhite()
    {
        myRenderer.material.shader = shaderGUItext;
        myRenderer.color = Color.white;
    }

    private void FlashToNormal()
    {
        myRenderer.material.shader = shaderSpritesDefault;
        myRenderer.color = Color.white;
    }
}
