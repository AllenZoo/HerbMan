using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    private Player player;
    private Slider slider;

    private GameObject levelDisplay;
    TextMeshProUGUI levelText;
    TextMeshProUGUI percentageText;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        slider = transform.Find("Slider").GetComponent<Slider>();

        levelDisplay = transform.Find("Background").gameObject;

        //Level
        levelText = levelDisplay.transform.Find("levelText").GetComponent<TextMeshProUGUI>();

        //Percentage
        percentageText = levelDisplay.transform.Find("percentageText").GetComponent<TextMeshProUGUI>();

    }

    private void Start()
    {
        player.player_Event.RegisterOnLeveledUp(RefreshLevelNumberUI);
        RefreshLevelNumberUI();

        player.player_Event.ResgisterOnExpChanged(RefreshLevelPercentageUI);
        RefreshLevelPercentageUI();
    }

    private void RefreshLevelPercentageUI()
    {
        percentageText.text = string.Concat(player.level.GetPercentageTowardsNextLevel().ToString("F2") + "%");
        slider.value = player.level.GetPercentageTowardsNextLevel()/100;
    }

    private void RefreshLevelNumberUI()
    {
        levelText.text = string.Concat(player.level.GetCurLevel());
        
    }


}
