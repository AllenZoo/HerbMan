using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stipp_DamagedBehaviour : StateMachineBehaviour
{
    private Enemy_Stipp_Controller controller;

    //Start
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller = animator.GetComponent<Enemy_Stipp_Controller>();
    }

    //Update
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller.GetComponent<Enemy_Effects>().FlickerWhite(controller.movementController.knockBackTime);
    }

    //Stop
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

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
