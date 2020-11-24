using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Initializer : MonoBehaviour
{
    [SerializeField] 
    private Player player;
    [SerializeField] private UI_Inventory uiInventory;

    [SerializeField] private UI_CharacterEquipment uiCharacterEquipment;
    private CharacterEquipment characterEquipment;

    [SerializeField] private UI_CraftingSystem uiCraftingSystem;
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


        uiCharacterEquipment.SetCharacterEquipment(characterEquipment);
        uiCharacterEquipment.SetInventory(player.GetInventory());

        uiCraftingSystem.SetCraftingSystem(craftingSystem);
        uiCraftingSystem.SetInventory(player.GetInventory());
    }

}
