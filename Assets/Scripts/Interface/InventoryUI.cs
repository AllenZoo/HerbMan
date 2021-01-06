using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DynamicInterface))]
public class InventoryUI : MonoBehaviour
{
    private void Awake()
    {
        FindObjectOfType<UI_Manager>()?.SetUIInventory(this.gameObject);
    }
}
