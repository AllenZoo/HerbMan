using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public UI_Manager uI_Manager;

    private const float ORBIT_DASH_SPEED = 200f;
    private float moveSpeed = 7f;

    [SerializeField] private LayerMask dashLayerMask;

    private Player_Animation playerAnimation;

    private Vector3 moveDir;
    private Vector3 lastMoveDir;
    private Vector3 mouseDir;
    private Vector2 movement;
    private Vector2 mouseMovement;

    private bool isSprintButtonDown = false;
    private bool isLongDashButtonDown = false;
    private bool isOrbitDashButtonDown = false;

    private Rigidbody2D rb;


    private bool CanMove(Vector3 moveDir, float distance)
    {
        return Physics2D.Raycast(transform.position, moveDir, distance).collider == null;
    }
    private void HandleInput()
    {
        //Sprint
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprintButtonDown = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprintButtonDown = false;
        }

        //Dash
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isLongDashButtonDown = true;
        }
        //Click Dash
        if (Input.GetMouseButtonDown(0))
        {
            isOrbitDashButtonDown = true;
        }
    }


    private void HandleMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(movement.x, movement.y).normalized;

        if(movement.x != 0 || movement.y != 0)
        {
            //Not idle
            lastMoveDir = moveDir;
        }

        playerAnimation.PlayerMoveAnim(moveDir);
    }
    private void HandleSprint()
    {
        if (isSprintButtonDown)
        {
            moveSpeed = 10;
        }
        //if out of stamina, isSprintButtonDown = false;
        else
        {
            moveSpeed = 7;
        }
    }
    private void HandleLongDash()
    {
        if (isLongDashButtonDown)
        {
            float dashAmount = 2f;
            Vector3 dashPosition = transform.position + lastMoveDir * dashAmount;

            RaycastHit2D raycastHid2d = Physics2D.Raycast(transform.position, moveDir, dashAmount, dashLayerMask);
            if (raycastHid2d.collider != null)
            {
                dashPosition = raycastHid2d.point;
            }

            rb.MovePosition(dashPosition);
            isLongDashButtonDown = false;
        }

    }
    private void HandleOrbitDash()
    {
        if (isOrbitDashButtonDown)
        {
            mouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseMovement = (mouseDir - transform.position).normalized;
            rb.velocity = new Vector2(mouseMovement.x * ORBIT_DASH_SPEED, mouseMovement.y * ORBIT_DASH_SPEED);

            playerAnimation.PlayerMoveAnim(mouseDir);

            isOrbitDashButtonDown = false;
        }
    }
   

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Player_Animation>();
    }
    private void Update()
    {
       
        HandleMovement();
        HandleInput();

    }
    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        rb.velocity = moveDir * moveSpeed;
        HandleSprint();
        HandleLongDash();
        HandleOrbitDash();

        
    }
}
