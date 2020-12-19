using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{
    public static Player_Stats Instance { get; private set; }

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
    private float level = 1;
    private float experience = 0;


    //Stats

    private float attack = 1;
    private float defence = 1;
    private float speed = 1;

    

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
        Instance = this;
        player = GetComponent<Player>();
    }
    private void Start()
    {

        RefillBars();
        OnHealthChanged += Player_Stats_OnHealthChanged;
        OnStaminaUsed += Player_Stats_OnStaminaChanged;
        OnLevelUp += Player_Stats_OnLevelUp;
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

    //ATTACK
    public float GetAttack()
    {
        return attack;
    }
    public void AddAttack(float num)
    {
        attack += num;
        OnStatChanged.Invoke(this, EventArgs.Empty);
    }
    public void SubtractAttack(float num)
    {
        attack -= num;
        OnStatChanged.Invoke(this, EventArgs.Empty);
    }
    public void SetAttack(float num)
    {
        attack = num;
        OnStatChanged.Invoke(this, EventArgs.Empty);
    }

    //DEFENCE
    public float GetDefence()
    {
        return defence;
    }
    public void AddDefence(float num)
    {
        defence += num;
        OnStatChanged.Invoke(this, EventArgs.Empty);
    }
    public void SubtractDefence(float num)
    {
        defence -= num;
        OnStatChanged.Invoke(this, EventArgs.Empty);
    }
    public void SetDefence(float num)
    {
        defence = num;
        OnStatChanged.Invoke(this, EventArgs.Empty);
    }

    //SPEED
    public float GetSpeed()
    {
        return speed;
    }
    public void AddSpeed(float num)
    {
        speed += num;
        OnStatChanged.Invoke(this, EventArgs.Empty);
    }
    public void SubtractSpeed(float num)
    {
        speed -= num;
        OnStatChanged.Invoke(this, EventArgs.Empty);
    }
    public void SetSpeed(float num)
    {
        speed = num;
        OnStatChanged.Invoke(this, EventArgs.Empty);
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

    private void Player_Stats_OnHealthChanged(object sender, EventArgs e)
    {
        CheckForDeath();
    }
    private void Player_Stats_OnStaminaChanged(object sender, EventArgs e)
    {

    }
    private void Player_Stats_OnLevelUp(object sender, EventArgs e)
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
   