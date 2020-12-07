using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MoneyCount : MonoBehaviour
{
    private GameObject npcTrader;
    private Text moneyText;
    private float money;

    private void Awake()
    {
        npcTrader = GameObject.FindGameObjectWithTag("NPC_Trader");
        moneyText = GetComponent<Text>();
    }

    private void Start()
    {

        npcTrader.GetComponent<NPC_Trader_QuestManager>().OnQuestCompletion += npcTrader_OnQuestCompletion;
    }

    private void npcTrader_OnQuestCompletion(object sender, System.EventArgs e)
    {
        RefreshUI();
    }
    private void RefreshUI()
    {
        money = Player_Base.Instance.GetMoney();
        moneyText.text = "Money: " + money;
    }
}
