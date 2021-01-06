using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StaticInterface))]
public class EquipmentUI : MonoBehaviour
{
    private void Awake()
    {
        FindObjectOfType<UI_Manager>()?.SetUIEquipment(this.gameObject);
    }
}
