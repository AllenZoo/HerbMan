using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RewardDisplay : MonoBehaviour
{
    private TextMeshProUGUI amountText;
    private Image itemDisplay;
    private void Awake()
    {
        amountText = GetComponentInChildren<TextMeshProUGUI>();
        itemDisplay = GetComponentInChildren<Image>();
    }

    public void SetAmountText(int amount)
    {
        amountText.text = " x " + amount;
    }

    public void SetItemDisplay(ItemObject item)
    {
        itemDisplay.sprite = item.sprite;
    }
}
