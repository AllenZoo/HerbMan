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
            bar.maxValue = player.GetComponent<Player_Base>().GetMaxHealth();
            player.GetComponent<Player_Base>().OnHealthChanged += StatBar_OnStatChanged;
        }
        else if (isStaminaBar)
        {
            bar.maxValue = player.GetComponent<Player_Base>().GetMaxStamina();
            player.GetComponent<Player_Base>().OnStaminaUsed += StatBar_OnStatChanged;
        }
        bar.minValue = 0;
        bar.value = bar.maxValue;


        
    }

    private void StatBar_OnStatChanged(object sender, System.EventArgs e)
    {
        if (isHealthBar)
        {
            bar.value = player.GetComponent<Player_Base>().GetHealth();
        }
        else if (isStaminaBar)
        {
            bar.value = player.GetComponent<Player_Base>().GetStamina();
        }
    }
}
