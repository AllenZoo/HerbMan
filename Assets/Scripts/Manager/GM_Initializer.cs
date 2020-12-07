using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Initializer : MonoBehaviour
{
    [SerializeField] 
    private Player player;
    private UI_Inventory uiInventory;

    private UI_CharacterEquipment uiCharacterEquipment;
    private CharacterEquipment characterEquipment;

    private UI_CraftingSystem uiCraftingSystem;
    private CraftingSystem craftingSystem;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        characterEquipment = player.GetComponent<CharacterEquipment>();
        craftingSystem = player.GetComponent<CraftingSystem>();

        uiInventory.SetPlayer(player);
        uiInventory.SetCharacterEquipment(characterEquipment);
        uiInventory.SetCraftingSystem(craftingSystem);
        uiInventory.SetInventory(player.GetInventory());

        uiCharacterEquipment.SetInventory(player.GetInventory());

        uiCraftingSystem.SetCraftingSystem(craftingSystem);
        uiCraftingSystem.SetInventory(player.GetInventory());
    }
    public void SetUIInventory(UI_Inventory uiInventory)
    {
        this.uiInventory = uiInventory;
    }
    public void SetUICharacterEquipment(UI_CharacterEquipment uiCharacterEquipment)
    {
        this.uiCharacterEquipment = uiCharacterEquipment;
    }
    public void SetUICraftingSystem(UI_CraftingSystem uiCraftingSystem)
    {
        this.uiCraftingSystem = uiCraftingSystem;
    }
}
