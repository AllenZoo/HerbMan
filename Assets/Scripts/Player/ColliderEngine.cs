using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEngine : MonoBehaviour
{
    private GameObject player;
    private Enemy_Base enemy_Base;
    private ItemWorld itemWorld;
    private ItemWorldVein itemWorldVein;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnEnable()
    {
        enemy_Base = null;
        itemWorld = null;
        itemWorldVein = null;
    }

    //Class is turned off when no TriggerCollision
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Item")
        {
            itemWorld = collider.GetComponent<ItemWorld>();
            player.GetComponent<Player>().GetInventory().AddItem(itemWorld.GetItem());
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
            player.GetComponent<Player_Movement>().KnockedBack(enemy_Base.GetKnockbackAmount(), collider.gameObject);
            player.GetComponent<Player>().TakeDamage(enemy_Base.GetCollsionDamage());
        }
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
                    player.GetComponent<Player>().GetInventory().AddItem(itemWorldVein.Harvest());
                }
            }
        }
    }
}
