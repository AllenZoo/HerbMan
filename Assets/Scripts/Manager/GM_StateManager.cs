using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_StateManager : MonoBehaviour
{
    [SerializeField] private GameObject screenDimmer;

    private GameObject player;
    private Player_Actions playerInput;
    private GameState gameState;

    public bool inInventory;
    public bool inCrafting;
    public bool inQuest;
    public bool inDialogue;

    public enum GameState
    {
        inNothing,
        inDialogue,
        inInventory_inCrafting,
        inQuest,
    }
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        
    }

    public GameState GetState()
    {
        return gameState;
    }
    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        RefreshFunctions();
    }
    public void SetStatus(string system, bool isOpen)
    {
        switch (system)
        {
            case "Inventory": inInventory = isOpen; break;
            case "Crafting": inCrafting = isOpen; break;
            case "Quest": inQuest = isOpen; break;
            case "Dialogue": inDialogue = isOpen; break;
        }
        RefreshFunctions();
    }

    private void RefreshFunctions()
    {
        if (CanPlayerMove())
        {
            //player.GetComponent<Player_Movement>().enabled = true;
            player.GetComponent<Player_Actions>().SetCanMove(true);
            player.transform.Find("Orbiter").GetComponent<OrbitController>().enabled = true;
        }
        else
        {
            //player.GetComponent<Player_Movement>().enabled = false;
            player.GetComponent<Player_Actions>().SetCanMove(false);
            player.transform.Find("Orbiter").GetComponent<OrbitController>().enabled = false;
        }

        if (inDialogue)
        {
            screenDimmer.SetActive(true);
        }
        else
        {
            screenDimmer.SetActive(false);
        }
    }
    private bool CanPlayerMove()
    {
        if(!inInventory && !inCrafting && !inQuest && !inDialogue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}
