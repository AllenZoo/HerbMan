using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Animator))]
public class Player_Animation : MonoBehaviour
{
    [SerializeField] Player player;
    private Animator animator;

    private string currentAnimationState;
    public enum AnimationState
    {
        Attack,
        Walk,
        Run,
        Dash,
    }

    //Animation States
    private const string PLAYER_ATTACK = "Player_Attack";
    private const string PLAYER_IDLE = "Player_Idle";
    private const string PLAYER_WALK = "Player_Walk";
    private const string PLAYER_RUN = "Player_Run";

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Start()
    {
        animator = player.animator;
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

    public void ChangeAnimationState(string newState)
    {
        if (currentAnimationState == newState)
        {
            return;
        }

        animator.Play(newState);

        currentAnimationState = newState;
    }
    
    
}
