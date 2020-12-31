using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    [SerializeField] internal Player player;

    //Inputs
    internal bool isSprintButtonDown = false; //SHIFT
    internal bool isLongDashButtonDown = false; //SPACE

    internal bool isRightButtonDown = false;
    internal bool isLeftButtonDown = false;
    internal bool isUpButtonDown = false;
    internal bool isDownButtonDown = false;

    internal bool isHorizontalMovementButtonDown = false; //A, D
    internal bool isVerticalMovementButtonDown = false; //W,S

    //Other
    private Vector2 movement;
    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isLongDashButtonDown = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isLongDashButtonDown = false;
        }

        ////Orbit Flash
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    isOrbitDashButtonDown = true;
        //}
        //else if (Input.GetKeyUp(KeyCode.G))
        //{
        //    isOrbitDashButtonDown = false;
        //}
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
