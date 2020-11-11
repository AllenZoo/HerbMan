using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void PlayerMoveAnim(Vector3 moveDir)
    {
        animator.SetFloat("Horizontal", moveDir.x);
        animator.SetFloat("Vertical", moveDir.y);
        animator.SetFloat("Magnitude", moveDir.magnitude);

        if (moveDir.x == 1 || moveDir.x == -1)
        {
            animator.SetFloat("LastMoveY", 0);
            animator.SetFloat("LastMoveX", moveDir.x);
        }
        if (moveDir.y == 1 || moveDir.y == -1)
        {
            animator.SetFloat("LastMoveX", moveDir.x);
            animator.SetFloat("LastMoveY", moveDir.y);
        }
    }

    
}
