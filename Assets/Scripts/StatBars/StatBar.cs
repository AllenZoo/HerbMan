using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    [SerializeField] bool isHealthBar = false;
    [SerializeField] bool isStaminaBar = false;

    private Slider bar;
    private GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bar = this.GetComponent<Slider>();

        if (isHealthBar)
        {
            bar.maxValue = player.GetComponent<Player_Stats>().GetMaxHealth();
            player.GetComponent<Player_Stats>().OnHealthChanged += StatBar_OnStatChanged;
        }
        else if (isStaminaBar)
        {
            bar.maxValue = player.GetComponent<Player_Stats>().GetMaxStamina();
            player.GetComponent<Player_Stats>().OnStaminaUsed += StatBar_OnStatChanged;
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
            bar.value = player.GetComponent<Player_Stats>().GetHealth();
        }
        else if (isStaminaBar)
        {
            bar.value = player.GetComponent<Player_Stats>().GetStamina();
        }
    }
}
