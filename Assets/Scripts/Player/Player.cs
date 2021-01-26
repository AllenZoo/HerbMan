using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Player_Stats))]
[RequireComponent(typeof(Player_Animation))]
[RequireComponent(typeof(Player_Collision))]
[RequireComponent(typeof(Player_Actions))]
[RequireComponent(typeof(Player_Input))]
[RequireComponent(typeof(Player_Equipment))]
[RequireComponent(typeof(Player_Quest))]
[RequireComponent(typeof(Player_Events))]
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public Level level;
    //Events
    internal event EventHandler OnEquipChanged;

    //Sub classes
    internal Player_Animation player_Animation;
    internal Player_Stats player_Stats;
    internal Player_Collision player_Collision;
    internal Player_Actions player_Actions;
    internal Player_Input player_Input;
    internal Player_Equipment player_Equipment;
    internal Player_Quest player_Quest;
    internal Player_Events player_Event;

    //Components
    internal Animator animator;
    internal Rigidbody2D rb2D;

    //Other
    public InventoryObject inventory;
    public InventoryObject equipment;
    public InventoryObject crafting;

    private void Awake()
    {
        Instance = this;

        player_Animation = GetComponent<Player_Animation>();
        player_Stats = GetComponent<Player_Stats>();
        player_Collision = GetComponent<Player_Collision>();
        player_Actions = GetComponent<Player_Actions>();
        player_Input = GetComponent<Player_Input>();
        player_Equipment = GetComponent<Player_Equipment>();
        player_Quest = GetComponent<Player_Quest>();
        player_Event = GetComponent<Player_Events>();

        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        level = new Level(1, OnLevelUp, OnExpChange);
        player_Event.InvokeOnLeveledUp();
    }

    public void TakeDamage(float num)
    {
        Debug.Log("taking damage");
        player_Stats.SubtractHealth(num);
    }
    public InventoryObject GetInventory()
    {
        return inventory;
    }
    public Vector3 GetPosition()
    {
        return this.transform.position;
    }

    public void OnLevelUp()
    {
        Debug.Log("Player: levelled up!");
        player_Event.InvokeOnLeveledUp();
    }

    public void OnExpChange()
    {
        player_Event.InvokeOnExpChanged();
    }

    public int GetLevel()
    {
        return level.GetCurLevel();
    }

    private void OnApplicationQuit()
    {
        inventory.container.Clear();
        equipment.container.Clear();
        crafting.container.Clear();
    }
}
