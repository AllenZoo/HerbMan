using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Actions : MonoBehaviour
{

    [SerializeField] internal Player player;
    private Player_Input player_Input;

    [SerializeField] private LayerMask dashLayerMask;
    [SerializeField] private LayerMask attackLayerMask;
    [SerializeField] private UI_Manager uI_Manager;

    private float moveSpeed;

    private Vector3 moveDir;
    private Vector3 lastMoveDir;
    private Vector2 movement;

    private bool isLongDashCD = false;
    private float longDashCooldown = 5f;

    //Non-Action States
    private bool isIdling = true;

    //Action States
    //private bool inActionState = false;
    private bool isMoving = false;
    private bool isSprinting = false;
    private bool isAttacking = false;


    private bool canMove = true;
    private bool outOfStamina = false;

    private bool canAttack = true;
    [SerializeField] private float attackDelay = 2f;
    [SerializeField] private float attackRange = 300f;

    private Rigidbody2D rb;

    private void Awake()
    {
        player = GetComponent<Player>();
        player_Input = player.player_Input;
    }
    private void Start()
    {
        rb = player.rb2D;
    }
    private void Update()
    {
        if (canMove)
        {
            movement.x = player.player_Input.axisInputX;
            movement.y = player.player_Input.axisInputY;
        }

        //IDLE
        if ((!isSprinting && !isMoving && !isAttacking) || !canMove)
        {
            isIdling = true;
            player.player_Animation.ChangeAnimationState(ActionType.Idle);
        }
        else
        {
            isIdling = false;
        }

        if (!isAttacking)
        {
            //MOVING
            //Debug.Log(movement + " " + (movement != new Vector2(0,0)));
            if (!isMoving && canMove && player_Input.IsMovementKeyPressed())
            {
                isMoving = true;
                //player.player_Animation.ChangeAnimationState(ActionType.Moving);
            }
            else if (player_Input.IsMovementKeyReleased())
            {
                isMoving = false;
            }
            if (isMoving)
            {
                player.player_Animation.ChangeAnimationState(ActionType.Moving);
            }

            //SPRINT
            if (!isSprinting && player_Input.IsKeyPressed(player_Input.SprintButtonInput))
            {
                isSprinting = true;
            }
            else if (player_Input.IsKeyReleased(player_Input.SprintButtonInput))
            {
                isSprinting = false;
            }

            if (isSprinting)
            {
                player.player_Animation.ChangeAnimationState(ActionType.Moving);
            }

        }

        //ATTACK
        if (!isAttacking && player_Input.IsKeyPressed(player_Input.AttackButtonInput))
        {
            isAttacking = true;

            if (isAttacking)
            {
                player.player_Animation.ChangeAnimationState(ActionType.Attack);
            }
            StopCoroutine(AttackDelay());
            StartCoroutine(AttackDelay());
        }

        //HANDLES ANIMATION DIRECTION
        if (CanChangeDirection())
        {
            player.player_Animation.PlayerMoveAnim(moveDir);
        }
    }
    private void FixedUpdate()
    {
        //IDLE
        if (isIdling)
        {
            rb.velocity = new Vector2(0, 0);
        }

        //MOVING


        if (isMoving && canMove && !isAttacking)
        {
            rb.velocity = moveDir * moveSpeed;

            //HandleLongDash();
            //player.player_Animation.ChangeAnimationState(ActionType.Moving);
        }

        if (isMoving)
        {
            HandleMovement();
        }

        if (isSprinting)
        {
            HandleSprint();
        }

        //ATTACKING
        if (isAttacking == true)
        {
            //Stop moving
            rb.velocity = new Vector2(0, 0);

            //Attack
            HandleAttack();

        }
    }

    public void SetCanMove(bool canMove)
    {
        this.canMove = canMove;
        if (!canMove)
        {
            player.player_Animation.PlayerMoveAnim(new Vector3(0, 0, 0));
        }
    }
    public void KnockedBack(float amount, GameObject enemy)
    {
        //Debug.Log("Player pos: " + this.transform.position + "Enemy pos: " + enemy.transform.position);
        Vector2 knockbackDir = (transform.position - enemy.transform.position).normalized;
        Vector2 knockbackPosition = new Vector2(transform.position.x + knockbackDir.x, transform.position.y + knockbackDir.y);


        //RaycastHit2D raycastHid2d = Physics2D.Raycast(transform.position, knockbackDir, amount, dashLayerMask);
        //if (raycastHid2d.collider != null)
        //{
        //    knockbackPosition = raycastHid2d.point;
        //}

        transform.position = knockbackPosition;
        rb.MovePosition(knockbackPosition * amount);
    }

    private void HandleMovement()
    {
        moveSpeed = 7;
        moveDir = new Vector3(movement.x, movement.y).normalized;
    }
    private void HandleSprint()
    {
        //Runs only when Sprint ButtonInput is pressed.

        //Check for stamina amount
        if (player.player_Stats.GetStamina() < 1)
        {
            //Stop sprinting
            moveSpeed = 7;
        }

        else //if (isMoving)
        {
            moveSpeed = 10;
            player.player_Stats.UseStamina(1);
        }

        //else
        //{
        //    moveSpeed = 7;
        //}
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
        else if (player.player_Input.isLongDashButtonDown && isLongDashCD)
        {
            Debug.Log("Long dash is on cooldown!");
        }

    }
    private void HandleAttack()
    {

        Vector2 dir;
        RaycastHit2D hit;

        //var dir = lastMoveDir;
        dir = new Vector2(player.player_Animation.animator.GetFloat("LastMoveX"), player.player_Animation.animator.GetFloat("LastMoveY"));
        hit = Physics2D.Raycast(transform.position, transform.TransformDirection(dir), attackRange, attackLayerMask);

        if(hit.collider != null && canAttack)
        {
            Debug.Log("Attacked");
            Enemy_Base enemy = hit.collider.GetComponent<Enemy_Base>();
            enemy.TakeDamage(1, "Player");
            canAttack = false;
            Invoke("ResetAttack", attackDelay); 
        }
        //Debug.Log("Hitting: " + hit.collider?.name);
        //Debug.DrawRay(transform.position, dir, Color.red, attackRange);

        

    }
    private IEnumerator StartLongDashCD(float time)
    {
        isLongDashCD = true;
        yield return new WaitForSeconds(time);
        isLongDashCD = false;
    }


    private IEnumerator AttackDelay()
    {
        Debug.Log("Is Attacking : " + isAttacking);
        yield return new WaitForSeconds(attackDelay);
        isAttacking = false;
        Debug.Log("Is Attacking : " + isAttacking);
    }
    private void AttackComplete()
    {
        isAttacking = false;
    }

    private void ResetAttack()
    {
        canAttack = true;
    }

    private bool CanChangeDirection()
    {
        if(isAttacking == false)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    private bool CheckForIdle()
    {
        Debug.Log(!isSprinting && !isMoving && !isAttacking);
        return (!isSprinting && !isMoving && !isAttacking);
    }
}
