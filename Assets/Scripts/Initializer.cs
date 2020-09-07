using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private UI_Inventory uiInventory;

    [SerializeField] private UI_CharacterEquipment uiCharacterEquipment;
    [SerializeField] private CharacterEquipment characterEquipment;

    private void Start()
    {
        uiInventory.SetPlayer(player);
        uiInventory.SetInventory(player.GetInventory());

        uiCharacterEquipment.SetCharacterEquipment(characterEquipment);
        uiCharacterEquipment.SetInventory(player.GetInventory());
    }

}
