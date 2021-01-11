using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    [SerializeField] internal Player player;

    [SerializeField] private LayerMask dashLayerMask;
    [SerializeField] private UI_Manager uI_Manager;

    private float moveSpeed;


    //private Player_Animation playerAnimation;
    //private Player_Base playerBase;

    private Vector3 moveDir;
    private Vector3 lastMoveDir;
    private Vector2 movement;

    private bool isLongDashCD = false;
    private float longDashCooldown = 5f;


    private bool isMoving = false;
    private bool canMove = true;
    private bool outOfStamina = false;

    private Rigidbody2D rb;

    private void Awake()
    {
        player = GetComponent<Player>();
    }
    private void Start()
    {
        rb = player.rb2D;
    }
    private void Update()
    {
        if (canMove)
        {
            HandleMovement();
            HandleOrbitTeleport();
        }
    }
    private void FixedUpdate()
    {
        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log("X: " + mousePosition.x + " Y: "+ mousePosition.y +" Z: "+ mousePosition.z+" Magnitude: "+ mousePosition.magnitude);

        //rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        if (isMoving && canMove)
        {
            rb.velocity = moveDir * moveSpeed;
            HandleSprint();
            HandleLongDash();
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }

    }

    public void SetCanMove(bool canMove)
    {
        this.canMove = canMove;
        if (!canMove)
        {
            player.player_Animation.PlayerMoveAnim(new Vector3(0,0,0));
        }
    }
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

        player.player_Animation.PlayerMoveAnim(moveDir);
    }

    private void HandleSprint()
    {
        if (player.player_Stats.GetStamina() < 1)
        {
            //Stop sprinting
            moveSpeed = 7;
        }
        else if (player.player_Input.isSprintButtonDown && isMoving)
        {
            moveSpeed = 10;
            player.player_Stats.UseStamina(1);
        }
        else
        {
            moveSpeed = 7;
        }
    }
    private void HandleLongDash()
    {
        if (player.player_Input.isLongDashButtonDown && !isLongDashCD && player.player_Stats.GetStamina() >= 10)
        {
            float dashAmount = 2f;
            Vector3 dashPosition = transform.position + lastMoveDir * dashAmount;
            player.player_Stats.UseStamina(10);
            RaycastHit2D raycastHid2d = Physics2D.Raycast(transform.position, moveDir, dashAmount, dashLayerMask);
            if (raycastHid2d.collider != null)
            {
                dashPosition = raycastHid2d.point;
            }

            rb.MovePosition(dashPosition);
            StartCoroutine(StartLongDashCD(longDashCooldown));
        }
        else if(player.player_Input.isLongDashButtonDown && isLongDashCD)
        {
            Debug.Log("Long dash is on cooldown!");
        }

    }
    private void HandleOrbitTeleport()
    {
        //if (isOrbitDashButtonDown)
        //{
        //    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    Vector3 newMousePosition = new Vector3(mousePosition.x, mousePosition.y, 0);
        //    //Vector2 mouseMovement = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y).normalized;
        //    //rb.velocity = new Vector2(mouseMovement.x * ORBIT_DASH_SPEED, mouseMovement.y * ORBIT_DASH_SPEED);
        //    //transform.position = new Vector2(mouseMovement.x * ORBIT_DASH_AMOUNT, mouseMovement.y * ORBIT_DASH_AMOUNT);
        //    //transform.position = new Vector2(transform.position.x + newMousePosition.x, transform.position.y + newMousePosition.y);

        //    isOrbitDashButtonDown = false;
        //}
    }
    private IEnumerator StartLongDashCD(float time)
    {
        isLongDashCD = true;
        yield return new WaitForSeconds(time);
        isLongDashCD = false;
    }
   
  

   
}
