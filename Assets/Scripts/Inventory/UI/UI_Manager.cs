using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory;

    public void CloseInventory()
    {
        uiInventory.gameObject.SetActive(false);
    }
    public void OpenInventory()
    {
        uiInventory.gameObject.SetActive(true);
    }

}
