using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public UI_Manager uI_Manager;

    private const float MOVE_SPEED = 10;

    [SerializeField] private LayerMask dashLayerMask;

    private Player_Animation playerAnimation;

    private Vector3 moveDir;
    private Vector3 mouseDir;
    private Vector2 movement;

    private bool isDashButtonDown = true;

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
        playerAnimation.PlayerMoveAnim(moveDir);
    }

    private void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isDashButtonDown = true;
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Player_Animation>();
    }
    private void Update()
    {
        mouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition).normalized;
        HandleMovement();
        HandleDash();

    }
    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        rb.velocity = moveDir * MOVE_SPEED;


        if (isDashButtonDown)
        {
            Debug.Log("dashing!");
            float dashAmount = 5f;
            Vector3 dashPosition = transform.position + moveDir * dashAmount;

            RaycastHit2D raycastHid2d = Physics2D.Raycast(transform.position, moveDir, dashAmount, dashLayerMask);
            if(raycastHid2d.collider != null)
            {
                dashPosition = raycastHid2d.point;
            }

            rb.MovePosition(dashPosition);
            isDashButtonDown = false;
        }
    }
}
