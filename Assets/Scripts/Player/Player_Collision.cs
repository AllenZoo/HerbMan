using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MonoBehaviour
{
    [SerializeField] internal Player player;
    //Other
    private bool isTouchingTrader;
    private Enemy_Base enemy_Base;
    private ItemWorld itemWorld;
    private ItemWorldVein itemWorldVein;
    private UI_Manager uiManager;

    private void Awake()
    {
        player = GetComponent<Player>();
        uiManager = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();
    }
    private void Start()
    {
        enemy_Base = null;
        itemWorld = null;
        itemWorldVein = null;
        isTouchingTrader = false;
    }

    //Class is turned off when no TriggerCollision
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Item")
        {
            itemWorld = collider.GetComponent<ItemWorld>();
            player.GetInventory().AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
        else if(collider.tag == "Item Vein")
        {
            itemWorld = collider.GetComponent<ItemWorld>();
            itemWorldVein = collider.GetComponent<ItemWorldVein>();
        }
        else if(collider.tag == "Enemy")
        {
            enemy_Base = collider.GetComponent<Enemy_Base>();
            player.player_Movement.KnockedBack(enemy_Base.GetKnockbackAmount(), collider.gameObject);
            player.TakeDamage(enemy_Base.GetCollsionDamage());
        }
        else if(collider.tag == "NPC_Trader")
        {
            isTouchingTrader = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        enemy_Base = null;
        itemWorld = null;
        itemWorldVein = null;
        isTouchingTrader = false;
    }

    void Update()
    {
        if (itemWorldVein != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                //OnCollisionVein?.Invoke(this, EventArgs.Empty);
                if (itemWorldVein.CanHarvest())
                {
                    player.GetInventory().AddItem(itemWorldVein.Harvest());
                }
            }
        }
        if (isTouchingTrader)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                uiManager.OpenTraderQuestInterface();
            }
        }
    }
}
