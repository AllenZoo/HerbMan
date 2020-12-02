using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Base : MonoBehaviour
{
    public static Player_Base Instance { get; private set; }

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
    private float level = 1;
    private float experience = 0;

    //Movement Speed
    private float speed = 1;

    //Knockback
    private float strength = 1;

    //Stamina Regen
    private float dexterity = 1;

    //Health Regen
    private float vitality = 1;


    private float health_WaitTimeRegen = 4f;
    private Coroutine health_Regen;

    private float stamina_WaitTimeRegen = 4f;
    private Coroutine stamina_Regen;

    public event EventHandler OnHealthChanged;
    public event EventHandler OnStaminaUsed;
    public event EventHandler OnManaChanged;
    public event EventHandler OnLevelUp;

    private void Awake()
    {
        Instance = this;
        RefillBars();
        OnHealthChanged += Player_Base_OnHealthChanged;
        OnStaminaUsed += Player_Base_OnStaminaChanged;
        OnLevelUp += Player_Base_OnLevelUp;
    }

  
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

    public float GetLevel()
    {
        return level;
    }
    public void LevelUp()
    {
        LevelUp(1);
    }
    public void LevelUp(float num)
    {
        level += num;
        ResetExperienceBar();
        OnLevelUp?.Invoke(this, EventArgs.Empty);
    }
    public void ResetExperienceBar()
    {
        experience = 0;
    }

    private void Player_Base_OnHealthChanged(object sender, EventArgs e)
    {
        CheckForDeath();
    }
    private void Player_Base_OnStaminaChanged(object sender, EventArgs e)
    {

    }
    private void Player_Base_OnLevelUp(object sender, EventArgs e)
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
   