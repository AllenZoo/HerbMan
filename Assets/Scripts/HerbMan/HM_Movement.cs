using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_Movement : MonoBehaviour
{
    public float moveSpeed = 7f;

    public Rigidbody2D rb;

    public Animator animator;

    Vector2 movement;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        if(movement.x == 1 || movement.x == -1)
        {
            animator.SetFloat("LastMoveY", 0);
            animator.SetFloat("LastMoveX", movement.x);
        }
        if(movement.y == 1 || movement.y == -1)
        {
            animator.SetFloat("LastMoveX", movement.x);
            animator.SetFloat("LastMoveY", movement.y);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

}
