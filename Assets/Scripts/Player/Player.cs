using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    //Events
    internal event EventHandler OnEquipChanged;

    //Sub classes
    internal Player_Animation player_Animation;
    internal Player_Stats player_Stats;
    internal Player_Collision player_Collision;
    internal Player_Movement player_Movement;
    internal Player_Input player_Input;

    //Components
    internal Animator animator;
    internal Rigidbody2D rb2D;

    //Other
    private Inventory inventory;

    private void Awake()
    {
        Instance = this;

        player_Animation = GetComponent<Player_Animation>();
        player_Stats = GetComponent<Player_Stats>();
        player_Collision = GetComponent<Player_Collision>();
        player_Movement = GetComponent<Player_Movement>();
        player_Input = GetComponent<Player_Input>();

        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();

        inventory = new Inventory(UseItem, 20);
    }

    private void Start()
    {
        //player_Collision.enabled = false;
    }

    //private void OnTriggerEnter2D(Collider2D collider)
    //{
    //    player_Collision.enabled = true;
    //}
    //private void OnTriggerExit2D(Collider2D collider)
    //{
    //    player_Collision.enabled = false;
    //}

    public void TakeDamage(float num)
    {
        Debug.Log("taking damage");
        player_Stats.SubtractHealth(num);
    }
    public Inventory GetInventory()
    {
        return inventory;
    }
    public Vector3 GetPosition()
    {
        return this.transform.position;
    }
    public void SetEquipment(Item item)
    {
        SetEquipment(item.itemType);
    }
    public void SetEquipment(Item.ItemType itemType)
    {
        switch (itemType)
        {
            default: break;
        }
        OnEquipChanged?.Invoke(this, EventArgs.Empty);
    }
    private void UseItem(Item item)
    {
        if (item.IsTool())
        {
            Debug.Log("Using Tool!");
            //Equip Tool
            switch (item.itemType)
            {
                default: break;
                case Item.ItemType.Stone_Pickaxe: break;

            }
        }

        if (item.IsMaterial())
        {
            switch (item.itemType)
            {
                default: break;
            }
        }
    }
   
}
