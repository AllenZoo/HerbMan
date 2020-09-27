using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public UI_Manager uI_Manager;

    private const float MOVE_SPEED = 7f;
    private const float ORBIT_DASH_SPEED = 200f;

    private enum State
    {

    }

    [SerializeField] private LayerMask dashLayerMask;

    private Player_Animation playerAnimation;

    private Vector3 moveDir;
    private Vector3 lastMoveDir;
    private Vector3 mouseDir;
    private Vector2 movement;
    private Vector2 mouseMovement;

    private bool isLongDashButtonDown = false;
    private bool isOrbitDashButtonDown = false;

    private Rigidbody2D rb;


    private bool CanMove(Vector3 moveDir, float distance)
    {
        return Physics2D.Raycast(transform.position, moveDir, distance).collider == null;
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

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isLongDashButtonDown = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            isOrbitDashButtonDown = true;
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
        rb.velocity = moveDir * MOVE_SPEED;
        HandleLongDash();
        HandleOrbitDash();

        
    }
}
