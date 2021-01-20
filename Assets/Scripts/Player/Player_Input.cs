using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Player))]
public class Player_Input : MonoBehaviour
{
    [SerializeField] internal Player player;

    //
    public Dictionary<KeyCode, bool> keys;

    //Inputs
    internal bool isAttackButtonDown = false; //SPACE

    internal bool isSprintButtonDown = false; //SHIFT
    internal bool isLongDashButtonDown = false; //T

    internal bool isRightButtonDown = false;
    internal bool isLeftButtonDown = false;
    internal bool isUpButtonDown = false;
    internal bool isDownButtonDown = false;

    internal bool isHorizontalMovementButtonDown = false; //A, D
    internal bool isVerticalMovementButtonDown = false; //W,S

    internal bool isKeycodeFDown = false;

    //Other
    private Vector2 movement;
    private void Awake()
    {
        player = GetComponent<Player>();
        keys = new Dictionary<KeyCode, bool>();
    }

    private void Update()
    {
        HandleInput();
    }

    public bool IsKeyPressed(KeyCode keyCode)
    {
        return Input.GetKeyDown(keyCode);
    }

    private void HandleInput()
    {
        //Interaction Button
        if (Input.GetKeyDown(KeyCode.F))
        {
            keys.Add(KeyCode.F, true);
        }
        else if(Input.GetKeyUp(KeyCode.F))
        {
            keys.Remove(KeyCode.F);
        }

        //Attack Button
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isAttackButtonDown = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space button up");
            isAttackButtonDown = false;
        }


        //Save Inventory
        if (Input.GetKeyDown(KeyCode.L))
        {
            player.inventory.Save();
            player.equipment.Save();
        }
        if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            player.inventory.Load();
            player.equipment.Load();
        }

        //Sprint
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprintButtonDown = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprintButtonDown = false;
        }

        //Dash
        if (Input.GetKeyDown(KeyCode.T))
        {
            isLongDashButtonDown = true;
        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
            isLongDashButtonDown = false;
        }

        //Test Input
        if (Input.GetKeyDown(KeyCode.M))
        {
            player.level.AddExp(999);
        }
    }

    private void RegularMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x == 1)
        {
            isRightButtonDown = true;
        }
        else if (movement.x == -1)
        {
            isLeftButtonDown = true;
        }
        else
        {
            isRightButtonDown = false;
            isLeftButtonDown = false;
        }

        if (movement.y == 1)
        {
            isUpButtonDown = true;
        }
        else if (movement.y == -1)
        {
            isDownButtonDown = true;
        }
        else
        {
            isUpButtonDown = false;
            isDownButtonDown = false;
        }
    }
}
