using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stipp_Animation : MonoBehaviour
{
    private Animator animator;
    private const string STIPP_IDLE = "Stipp_Idle";
    private const string STIPP_JUMP = "Stipp_Jump";
    private const string STIPP_FOLLOW = "Stipp_Follow";
    private const string STIPP_FROZEN = "Stipp_Frozen";

    public enum ActionState 
    {
        Idle,
        Jumping,
        Following,
        Frozen,
    }

    private ActionState actionState;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeState(ActionState actionState)
    {
        this.actionState = actionState;
        UpdateAnimatorState();
    }

    private void UpdateAnimatorState()
    {
        switch (actionState)
        {
            case ActionState.Idle:
                animator.Play(STIPP_IDLE);
                break;
            case ActionState.Jumping:
                animator.Play(STIPP_JUMP);
                break;
            case ActionState.Following:
                animator.Play(STIPP_FOLLOW);
                break;
            case ActionState.Frozen:
                animator.Play(STIPP_FROZEN);
                break;
            default:
                break;
        }
    }
}
