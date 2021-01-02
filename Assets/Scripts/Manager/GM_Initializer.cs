using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Initializer : MonoBehaviour
{
    private Player player;

    private UI_CraftingSystem uiCraftingSystem;
    private CraftingSystem craftingSystem;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        craftingSystem = player.GetComponent<CraftingSystem>();
    }
    private void Start()
    {

    }

    private void Initialize()
    {

    }

    public void SetUICraftingSystem(UI_CraftingSystem uiCraftingSystem)
    {
        this.uiCraftingSystem = uiCraftingSystem;
    }
}
