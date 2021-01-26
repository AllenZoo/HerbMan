using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CollisionEvent();
public class Player_Collision : MonoBehaviour
{
    [SerializeField] internal Player player;

    //...ables...
    private Collectable collectableRef;
    private Interactable interactableRef;

    //Other
    private bool isTouchingTrader;
    private bool isTouchingInteractable;
    private Enemy_Base enemy_Base;
    private UI_Manager uiManager;



    public event CollisionEvent CollectedCollectable;
    public event CollisionEvent InteractedInteracatable;

    private void Awake()
    {
        player = GetComponent<Player>();

    }
    private void Start()
    {
        enemy_Base = null;
        isTouchingTrader = false;
        isTouchingInteractable = false;
    }

    //Class is turned off when no TriggerCollision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Collectable")
        {
            collectableRef = other.GetComponent<Collectable>();
            collectableRef.Collect(player);
        }
        if(other.tag == "Interactable")
        {
            interactableRef = other.GetComponent<Interactable>();
            isTouchingInteractable = true;
        }

        else if(other.tag == "Enemy")
        {
            enemy_Base = other.GetComponent<Enemy_Base>();
            player.player_Actions.KnockedBack(enemy_Base.GetKnockbackAmount(), other.gameObject);
            player.TakeDamage(enemy_Base.GetCollsionDamage());
        }
        else if(other.tag == "NPC_Trader")
        {
            isTouchingTrader = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collectableRef = null;
        interactableRef = null;
        enemy_Base = null;
        isTouchingTrader = false;
        isTouchingInteractable = false;
    }

    void Update()
    {
        if (isTouchingInteractable && player.player_Input.IsKeyPressed(interactableRef.GetInputKey()))
        {
            interactableRef.Interact(player);
        }
    }

}
