using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingUI : MonoBehaviour
{
    private void Awake()
    {
        FindObjectOfType<UI_Manager>().SetUICrafting(this.gameObject.transform);
    }
}
