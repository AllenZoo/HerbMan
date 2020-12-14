using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialArrow : MonoBehaviour
{
    private Image image;
    private bool isFlashing;

    private void Awake()
    {
        image = GetComponent<Image>();
        isFlashing = false;
    }
    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void Update()
    {

    }

    public void StartFlashing()
    {
        isFlashing = true;
        Debug.Log(isFlashing);
        StartCoroutine(Flash());
    }
    public void StopFlashing()
    {
        isFlashing = false;
        StopAllCoroutines();
    }

    private IEnumerator Flash()
    {
        Debug.Log("Coroutine Started");
        Color tempColour = new Color(255, 255, 255, 1);
        float tempAlphaVal = 1;
        bool isFading = true;
        while (isFlashing)
        {
            Debug.Log(tempColour.a + " " + isFading);
            if (isFading)
            {
                tempAlphaVal -= 1/10;
                tempColour.a = tempAlphaVal;
                image.color = tempColour;

                if(tempAlphaVal == 0.1)
                {
                    isFading = false;
                }
                yield return new WaitForSeconds(1);
            }
            else if (!isFading)
            {
                tempColour.a += 1/10;
                image.color = tempColour;
                
                if(tempColour.a == 1)
                {
                    isFading = true;
                }
            }
            yield return new WaitForSeconds(1);
        }

        yield return null;
    }

}
