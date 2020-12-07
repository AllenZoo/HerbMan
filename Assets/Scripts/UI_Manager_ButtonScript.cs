using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager_ButtonScript : MonoBehaviour
{
    public ButtonType buttonType;
    private bool isOpen;
    private string system;

    public enum ButtonType
    {
        OpenInventory,
        CloseInventory,
        OpenCrafting,
        CloseCrafting,
        OpenQuest,
        CloseQuest,
    }

    private void Start()
    {
        UI_Manager_SetButton();
    }

    private void UI_Manager_SetButton()
    {
        switch (buttonType)
        {
            
            case ButtonType.OpenInventory: system = "Inventory"; isOpen = true; break;
            case ButtonType.CloseInventory: system = "Inventory"; isOpen = false; break;

            case ButtonType.OpenCrafting: system = "Crafting"; isOpen = true; break;
            case ButtonType.CloseCrafting: system = "Crafting"; isOpen = false; break;

            case ButtonType.OpenQuest: system = "Quest"; isOpen = true; break;
            case ButtonType.CloseQuest: system = "Quest"; isOpen = false; break;

        }

        FindObjectOfType<UI_Manager>().GetComponent<UI_Manager>().SetButton(this.gameObject.GetComponent<Button>(), isOpen, system);
    }
}
