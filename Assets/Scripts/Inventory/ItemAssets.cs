using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    //Tools
    public Sprite StonePickaxe;
    public Sprite IronPickaxe;
    public Sprite AmatitePickaxe;
    public Sprite StoneAxe;
    public Sprite IronAxe;
    public Sprite AmatiteAxe;
    public Sprite StoneSickle;
    public Sprite IronSickle;
    public Sprite AmatiteSickle;

    //Herbs
    public Sprite Melom;
    public Sprite Water_Herb;
    public Sprite Mellow_Mint;

    //Ores
    public Sprite Stone;
    public Sprite IronOre;
    public Sprite AmatiteOre;

    //Trees
    public Sprite Oak;
    public Sprite Pine;
    public Sprite Redwood;

}
