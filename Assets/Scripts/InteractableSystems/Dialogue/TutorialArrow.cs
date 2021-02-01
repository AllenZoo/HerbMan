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
        Color32 tempColour = new Color(255, 255, 255, 1);
        float tempAlphaVal = 255f;
        bool isFading = true;
        while (isFlashing)
        {

            if (isFading)
            {
                tempAlphaVal  -= 10;
                tempColour.a = (byte)tempAlphaVal;
                image.color = tempColour;

                if(tempAlphaVal == 15)
                {
                    isFading = false;
                }
                yield return new WaitForSeconds(1/5);
            }
            else if (!isFading)
            {
                tempAlphaVal += 10;
                tempColour.a = (byte)tempAlphaVal;
                image.color = tempColour;
                
                if(tempColour.a == 255)
                {
                    isFading = true;
                }
                yield return new WaitForSeconds(1 / 5);
            }

            //yield return new WaitForSeconds(1);
        }

        yield return null;
    }

}
