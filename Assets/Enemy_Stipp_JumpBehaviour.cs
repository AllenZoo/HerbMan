using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stipp_JumpBehaviour : StateMachineBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float escapeRange;
    private Transform player;
    private Enemy_Stipp_Controller controller;


    //Start
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        controller = animator.GetComponent<Enemy_Stipp_Controller>();

        //var tempDir = (player.transform.position - animator.transform.position).normalized;
        //controller.movementController.SetJumpDir(tempDir);
    }

    //Update
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (controller == null)
        {
            return;
        }

        if (!controller.movementController.isJumping)
        {
            //if --> isJumping = false
            CheckToFollow();
            CheckToIdle();
        }
    }

    //Stop
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    private void CheckToFollow()
    {
        var dist = Vector2.Distance(controller.transform.position, player.position);
        if(dist <= escapeRange)
        {
            controller.StartFollowState(1);
        }
    }
    private void CheckToIdle()
    {
        var dist = Vector2.Distance(controller.transform.position, player.position);
        if(dist >= escapeRange)
        {
            controller.StartIdleState();
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
