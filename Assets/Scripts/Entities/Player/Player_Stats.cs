using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{
    [SerializeField] internal Player player;

    //Stats
    [SerializeField] private float curHealth;
    //For Movement
    [SerializeField] private float curStamina;
    //For Orb Abilities
    [SerializeField] private float curMana;

    private float money = 0;

    private float maxHealth = 100;
    private float maxStamina = 100;
    private float maxMana = 100;
    private float experience = 0;

    public Attribute[] attributes;

    //Stamina Regen
    private float dexterity = 1;

    //Health Regen
    private float vitality = 1;


    private float health_WaitTimeRegen = 4f;
    private Coroutine health_Regen;

    private float stamina_WaitTimeRegen = 4f;
    private Coroutine stamina_Regen;

    public event EventHandler OnStatChanged;
    public event EventHandler OnHealthChanged;
    public event EventHandler OnStaminaUsed;
    public event EventHandler OnManaChanged;
    public event EventHandler OnLevelUp;

    private void Awake()
    {
        player = GetComponent<Player>();
    }
    private void Start()
    {

        for (int i = 0; i < attributes.Length; i++)
        {
            attributes[i].SetParent(this);
        }
        for (int i = 0; i < player.equipment.GetSlots.Length; i++)
        {
            player.equipment.GetSlots[i].OnBeforeUpdate += OnBeforeSlotUpdate;
            player.equipment.GetSlots[i].OnAfterUpdate += OnAfterSlotUpdate;
        }

        RefillBars();
        OnHealthChanged += Player_Stats_OnHealthChanged;
        OnStaminaUsed += Player_Stats_OnStaminaChanged;
    }

    public void OnBeforeSlotUpdate(InventorySlot _slot)
    {
        if(_slot.ItemObject == null)
        {
            return;
        }
        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
                break;
            case InterfaceType.Equipment:
                Debug.Log(string.Concat("Removed ", _slot.ItemObject, " on ", _slot.parent.inventory.type, " Allowed Items: ", string.Join(", ", _slot.allowedItems)));

                for (int i = 0; i < _slot.item.buffs.Length; i++)
                {
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        if (attributes[j].type == _slot.item.buffs[i].attribute)
                        {
                            attributes[j].value.RemoveModifier(_slot.item.buffs[i]);
                        }
                    }
                }

                break;
            case InterfaceType.Crafting:
                break;
            case InterfaceType.Quest:
                break;
            default:
                break;
        }
    }
    public void OnAfterSlotUpdate(InventorySlot _slot)
    {
        if (_slot.ItemObject == null)
        {
            return;
        }
        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
                break;
            case InterfaceType.Equipment:
                Debug.Log(string.Concat("Placed ", _slot.ItemObject, " on ", _slot.parent.inventory.type, " Allowed Items: ", string.Join(", ", _slot.allowedItems)));

                for (int i = 0; i < _slot.item.buffs.Length; i++)
                {
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        if(attributes[j].type == _slot.item.buffs[i].attribute)
                        {
                            attributes[j].value.AddModifier(_slot.item.buffs[i]);
                        }
                    }
                }

                break;
            case InterfaceType.Crafting:
                break;
            case InterfaceType.Quest:
                break;
            default:
                break;
        }
    }

    public void AttributeModified(Attribute attribute)
    {
        Debug.Log(string.Concat(attribute.type, " was updated! Value is now: ", attribute.value.ModifiedValue));
        OnStatChanged?.Invoke(this, EventArgs.Empty);
    }

    //ATTACK
    public float GetAttack()
    {
        for (int i = 0; i < attributes.Length - 1; i++)
        {
            if (attributes[i].type == Attributes.Attack)
            {
                return attributes[i].value.ModifiedValue;
            }
        }
        return -1;
    }
    //DEFENCE
    public float GetDefence()
    {
        for (int i = 0; i < attributes.Length - 1; i++)
        {
            if (attributes[i].type == Attributes.Defence)
            {
                return attributes[i].value.ModifiedValue;
            }
        }
        return -1;
    }
    //SPEED
    public float GetSpeed()
    {
        for (int i = 0; i < attributes.Length - 1; i++)
        {
            if (attributes[i].type == Attributes.Speed)
            {
                return attributes[i].value.ModifiedValue;
            }
        }
        return -1;
    }


    //MONEY
    public float GetMoney()
    {
        return money;
    }
    public void AddMoney(float num)
    {
        money += num;
    }
    public void SubtractMoney(float num)
    {
        money -= num;
    }
    public void SetMoney(float num)
    {
        money = num;
    }

    //HEALTH
    public float GetHealth()
    {
        return curHealth;
    }
    public float GetMaxHealth()
    {
        return maxHealth;
    }
    public void SubtractHealth(float num)
    {
        this.curHealth -= num;
        OnHealthChanged(this, EventArgs.Empty);
    }
    public void AddHealth(float num)
    {
        this.curHealth += num;
        OnHealthChanged(this, EventArgs.Empty);
    }
    public void SetHealth(float num)
    {
        this.curHealth = num;
        OnHealthChanged(this, EventArgs.Empty);
    }
    private IEnumerator HealthRegen()
    {
        yield return new WaitForSeconds(health_WaitTimeRegen);
        while (curHealth < maxHealth)
        {
            AddHealth(vitality);
            yield return new WaitForSeconds(1/5);
        }
    }

    //STAMINA
    public float GetStamina()
    {
        return curStamina;
    }
    public float GetMaxStamina()
    {
        return maxStamina;
    }
    public void SubtractStamina(float num)
    {
        curStamina -= num;
        OnStaminaUsed(this, EventArgs.Empty);
    }
    public void AddStamina(float num)
    {
        curStamina += num;
        OnStaminaUsed?.Invoke(this, EventArgs.Empty);
    }
    public void UseStamina(float num)
    {
        if(curStamina - num >= 0)
        {
            SubtractStamina(num);

            if(stamina_Regen != null)
            {
                StopCoroutine(stamina_Regen);
            }
            stamina_Regen = StartCoroutine(StaminaRegen());
        }
        else
        {
            Debug.Log("Not enough stamina");
        }
    }
    private IEnumerator StaminaRegen()
    {
        yield return new WaitForSeconds(stamina_WaitTimeRegen);
        while(curStamina < maxStamina)
        {
            AddStamina(dexterity/5);
            yield return new WaitForSeconds(1/5);
        }
    }

    private void Player_Stats_OnHealthChanged(object sender, EventArgs e)
    {
        CheckForDeath();
    }
    private void Player_Stats_OnStaminaChanged(object sender, EventArgs e)
    {

    }

    private void CheckForDeath()
    {
        if (curHealth <= 0)
        {
            Debug.Log("You died");
        }
    }
    public void RefillBars()
    {
        curHealth = maxHealth;
        curStamina = maxHealth;
    }

}
   