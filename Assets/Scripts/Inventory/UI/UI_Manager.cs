using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private Transform uiInventory;
    [SerializeField] private Transform hiddenArea;
    [SerializeField] private Transform visibleArea;
    private void Start()
    {
        visibleArea.transform.position = uiInventory.transform.position;
    }

    public void CloseInventory()
    {
        uiInventory.transform.position = hiddenArea.transform.position;
    }
    public void OpenInventory()
    {
        uiInventory.transform.position = visibleArea.transform.position;
    }

}
