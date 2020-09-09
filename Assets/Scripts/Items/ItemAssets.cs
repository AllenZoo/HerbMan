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

    [Header("Prefabs")]
    public Transform pfItemWorld;
    public Transform pfItemVein;

    [Header("Tools")]
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

    [Header("Materials")]
    //Herbs
    public Sprite Hemm;
    public Sprite Melom;
    public Sprite MellowMint;
    public Sprite WaterHerb;

    //Ores
    public Sprite Flint;
    public Sprite Stone;
    public Sprite IronOre;
    public Sprite AmatiteOre;

    //Wood
    public Sprite Stick;
    public Sprite Oak;
    public Sprite Pine;
    public Sprite Redwood;

    [Header("Veins")]
    //Herbs
    public Sprite MelomVein;
    public Sprite WaterHerbVein;
    public Sprite MellowMintVein;

    //Ores
    public Sprite StoneVein;
    public Sprite IronOreVein;
    public Sprite AmatiteOreVein;

    //Wood
    public Sprite OakVein;
    public Sprite PineVein;
    public Sprite RedwoodVein;
}
