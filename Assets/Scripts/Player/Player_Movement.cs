using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public UI_Manager uI_Manager;

    private const float ORBIT_DASH_AMOUNT = 5f;

    private float moveSpeed = 7f;

    [SerializeField] private LayerMask dashLayerMask;

    private Player_Animation playerAnimation;
    private Player_Base playerBase;

    private Vector3 moveDir;
    private Vector3 lastMoveDir;
    private Vector2 movement;

    private bool isSprintButtonDown = false;

    private bool isLongDashButtonDown = false;
    private bool isLongDashCD = false;
    private float longDashCooldown = 5f;

    private bool isOrbitDashButtonDown = false;

    private bool isMoving = false;

    private Rigidbody2D rb;

    public void KnockedBack(float amount, GameObject enemy)
    {
        Debug.Log("getting knocked back");
        Vector2 knockbackDir = (transform.position - enemy.transform.position).normalized;
        Vector2 knockbackPosition = new Vector2(transform.position.x + knockbackDir.x, transform.position.y + knockbackDir.y);


        RaycastHit2D raycastHid2d = Physics2D.Raycast(transform.position, knockbackDir, amount, dashLayerMask);
        if (raycastHid2d.collider != null)
        {
            knockbackPosition = raycastHid2d.point;
        }

        transform.position = knockbackPosition;
        //rb.MovePosition(knockbackPosition * amount);
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
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isLongDashButtonDown = false;
        }

        //Orbit Flash
        if (Input.GetKeyDown(KeyCode.G))
        {
            isOrbitDashButtonDown = true;
        }
        else if (Input.GetKeyUp(KeyCode.G))
        {
            isOrbitDashButtonDown = false;
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
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        playerAnimation.PlayerMoveAnim(moveDir);
    }
    private void HandleSprint()
    {
        if (playerBase.GetStamina() < 1)
        {
            //Stop sprinting
            isSprintButtonDown = false;
            moveSpeed = 7;
        }
        else if (isSprintButtonDown && isMoving)
        {
            moveSpeed = 10;
            playerBase.UseStamina(1);
        }
        else
        {
            moveSpeed = 7;
        }
    }
    private void HandleLongDash()
    {
        if (isLongDashButtonDown && !isLongDashCD)
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
            StartCoroutine(StartLongDashCD(longDashCooldown));
        }
        else if(isLongDashButtonDown && isLongDashCD)
        {
            Debug.Log("Long dash is on cooldown!");
        }

    }
    private void HandleOrbitTeleport()
    {
        if (isOrbitDashButtonDown)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newMousePosition = new Vector3(mousePosition.x, mousePosition.y, 0);
            //Vector2 mouseMovement = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y).normalized;
            //rb.velocity = new Vector2(mouseMovement.x * ORBIT_DASH_SPEED, mouseMovement.y * ORBIT_DASH_SPEED);
            //transform.position = new Vector2(mouseMovement.x * ORBIT_DASH_AMOUNT, mouseMovement.y * ORBIT_DASH_AMOUNT);
            //transform.position = new Vector2(transform.position.x + newMousePosition.x, transform.position.y + newMousePosition.y);

            isOrbitDashButtonDown = false;
        }
    }
    private IEnumerator StartLongDashCD(float time)
    {
        isLongDashCD = true;
        yield return new WaitForSeconds(time);
        isLongDashCD = false;
    }
   
  

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Player_Animation>();
        playerBase = GetComponent<Player_Base>();
    }
    private void Update()
    {
       
        HandleMovement();
        HandleInput();
        HandleOrbitTeleport();
    }
    private void FixedUpdate()
    {
        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log("X: " + mousePosition.x + " Y: "+ mousePosition.y +" Z: "+ mousePosition.z+" Magnitude: "+ mousePosition.magnitude);
        
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        if (isMoving)
        {
            rb.velocity = moveDir * moveSpeed;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
        HandleSprint();
        HandleLongDash();


        
    }
}
