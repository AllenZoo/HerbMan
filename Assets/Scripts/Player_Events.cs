using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Events : MonoBehaviour
{
    internal Player player;
    public EventHandler OnCollectedCollectable;
    public EventHandler OnItemAddedToInventory;

    private void Awake()
    {
        player = GetComponent<Player>();
    }
}
