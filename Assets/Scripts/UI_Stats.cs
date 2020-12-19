using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Stats : MonoBehaviour
{
    [SerializeField] private Player player;
    private Transform stats;

    private Text attackText;
    private Text defenceText;
    private Text speedText;


    private void Awake()
    {
        //Failsafe Player Reference
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        stats = this.transform.Find("Stats");
        attackText = stats.Find("attackText").GetComponent<Text>();
        defenceText = stats.Find("defenceText").GetComponent<Text>();
        speedText = stats.Find("speedText").GetComponent<Text>();
    }

    private void Start()
    {
        player.player_Stats.OnStatChanged += Player_Stats_OnStatChanged;
        RefreshUI();
    }

    private void Player_Stats_OnStatChanged(object sender, System.EventArgs e)
    {
        RefreshUI();
    }

    private void RefreshUI()
    {
        attackText.text = "Attack: " + player.player_Stats.GetAttack();
        defenceText.text = "Defence: " + player.player_Stats.GetDefence();
        speedText.text = "Speed: " + player.player_Stats.GetSpeed();
    }

    //TESTING
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.K))
    //    {
    //        player.player_Stats.AddAttack(1);
    //    }
    //}
}
