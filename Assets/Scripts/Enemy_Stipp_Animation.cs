using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stipp_Animation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StippJumpAnim(bool isJumping)
    {
        animator.SetBool("isJumping", isJumping);
    }
}
