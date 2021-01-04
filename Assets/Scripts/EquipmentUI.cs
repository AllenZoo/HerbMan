using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    private void Awake()
    {
        FindObjectOfType<UI_Manager>().SetUIEquipment(this.gameObject.transform);
    }
}
