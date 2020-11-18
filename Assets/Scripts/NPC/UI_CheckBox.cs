using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CheckBox : MonoBehaviour
{
    private Transform checkMark;

    private void Start()
    {
        checkMark = transform.Find("CheckMark");
    }

    public  void SetCheckMarkState(bool isActive)
    {
        checkMark.gameObject.SetActive(isActive);
    }
}
