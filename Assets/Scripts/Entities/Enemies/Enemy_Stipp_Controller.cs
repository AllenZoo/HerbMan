using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy_Base))]
[RequireComponent(typeof(Enemy_Stipp_Animation))]
public class Enemy_Stipp_Controller : MonoBehaviour
{
    internal Enemy_Base stats;
    internal Enemy_Stipp_Movement movementController;
    internal Enemy_Stipp_Animation animatorController;

    private Animator animator;

    private float health;
    private float moveSpeed;

    private Enemy_Base enemyBase;

    private void Awake()
    {
        stats = GetComponent<Enemy_Base>();
        movementController = GetComponent<Enemy_Stipp_Movement>();
        animatorController = GetComponent<Enemy_Stipp_Animation>();

        //Visual
        animator = GetComponent<Animator>();

        //Base (Stores stats)
        enemyBase = GetComponent<Enemy_Base>();
        RefreshStats();
    }


    
    private void RefreshStats()
    {
        health = enemyBase.GetHealth();
        moveSpeed = enemyBase.GetMoveSpeed();
    }

    public void StartJumpState()
    {
        animatorController.ChangeState(Enemy_Stipp_Animation.ActionState.Jumping);
        movementController.Jump(0);
    }
    public void StartJumpState(float transitionTime)
    {
        animatorController.ChangeState(Enemy_Stipp_Animation.ActionState.Jumping);
        movementController.Jump(transitionTime);
    }

    public void StartFollowState()
    {
        animatorController.ChangeState(Enemy_Stipp_Animation.ActionState.Following);
        movementController.Follow(0);
    }
    public void StartFollowState(float transitionTime)
    {
        animatorController.ChangeState(Enemy_Stipp_Animation.ActionState.Following);
        movementController.Follow(transitionTime);
    }

    public void StartIdleState()
    {
        animatorController.ChangeState(Enemy_Stipp_Animation.ActionState.Idle);
        movementController.Idle();
    }

}
