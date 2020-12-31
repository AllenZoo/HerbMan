using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Initializer : MonoBehaviour
{
    private Player player;

    private UI_CharacterEquipment uiCharacterEquipment;
    private Player_Equipment characterEquipment;

    private UI_CraftingSystem uiCraftingSystem;
    private CraftingSystem craftingSystem;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        characterEquipment = player.GetComponent<Player_Equipment>();
        craftingSystem = player.GetComponent<CraftingSystem>();
    }
    private void Start()
    {
        Invoke("Initialize", 0.1f);
    }

    private void Initialize()
    {
        //uiInventory.SetPlayer(player);
        //uiInventory.SetCharacterEquipment(characterEquipment);
        //uiInventory.SetCraftingSystem(craftingSystem);
        //uiInventory.SetInventory(player.GetInventory());

        //uiCharacterEquipment.SetInventory(player.GetInventory());
        //uiCharacterEquipment.SetCharacterEquipment(characterEquipment);

        //uiCraftingSystem.SetCraftingSystem(craftingSystem);
        //uiCraftingSystem.SetInventory(player.GetInventory());
    }

    public void SetUICraftingSystem(UI_CraftingSystem uiCraftingSystem)
    {
        this.uiCraftingSystem = uiCraftingSystem;
    }
}
