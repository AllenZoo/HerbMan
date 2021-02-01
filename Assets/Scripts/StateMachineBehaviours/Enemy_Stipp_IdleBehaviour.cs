using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stipp_IdleBehaviour : StateMachineBehaviour
{
    private Transform player;
    private Enemy_Stipp_Controller controller;

    [SerializeField] private float aggroRange = 5;

    //Start
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        controller = animator.GetComponent<Enemy_Stipp_Controller>();
    }

    //Update
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CheckToJump();
    }

    //Stop
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    private void CheckToJump()
    {
        var dist = Vector2.Distance(controller.transform.position, player.position);
        if (dist <= aggroRange)
        {
            Debug.Log("jumping at player");
            controller.StartJumpState(0);
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
