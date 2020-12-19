using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    [SerializeField] bool isHealthBar = false;
    [SerializeField] bool isStaminaBar = false;

    private Slider bar;
    private Player player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        bar = this.GetComponent<Slider>();
    }

    private void Start()
    {
        if (isHealthBar)
        {
            bar.maxValue = player.player_Stats.GetMaxHealth();
            player.player_Stats.OnHealthChanged += StatBar_OnStatChanged;
        }
        else if (isStaminaBar)
        {
            bar.maxValue = player.player_Stats.GetMaxStamina();
            player.player_Stats.OnStaminaUsed += StatBar_OnStatChanged;
        }
        bar.minValue = 0;
        bar.value = bar.maxValue;
    }
    public float GetMaxValue()
    {
        return bar.maxValue;
    }
    public float GetCurValue()
    {
        return bar.value;
    }

    private void StatBar_OnStatChanged(object sender, System.EventArgs e)
    {
        if (isHealthBar)
        {
            bar.value = player.player_Stats.GetHealth();
        }
        else if (isStaminaBar)
        {
            bar.value = player.player_Stats.GetStamina();
        }
    }
}
