using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Animator))]
public class Player_Animation : MonoBehaviour
{
    [SerializeField] Player player;
    internal Animator animator;

    private string currentAnimationState;

    //Animation States
    private const string PLAYER_ATTACK = "Player_Attack";
    private const string PLAYER_IDLE = "Player_Idle";
    private const string PLAYER_MOVING = "Player_Moving";
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
    public void ChangeAnimationState(ActionType actionType)
    {
        if (currentAnimationState == GetStateFromActionType(actionType))
        {
            return;
        }

        switch (actionType)
        {
            case ActionType.Idle:
                ChangeAnimationState(PLAYER_IDLE);
                break;
            case ActionType.Attack:
                ChangeAnimationState(PLAYER_ATTACK);
                break;
            case ActionType.Moving:
                ChangeAnimationState(PLAYER_MOVING);
                break;
            case ActionType.Run:
                Debug.Log("Animation has not been assigned");
                break;
            case ActionType.Dash:
                Debug.Log("Animation has not been assigned");
                break;
            
            default:
                Debug.Log("Animation has not been assigned");
                break;
        }
    }

    public string GetStateFromActionType(ActionType actionType)
    {
        switch (actionType)
        {
            case ActionType.Idle:
                return PLAYER_IDLE;
            case ActionType.Attack:
                return PLAYER_ATTACK;
            case ActionType.Moving:
                return PLAYER_MOVING;
            case ActionType.Run:
                break;
            case ActionType.Dash:
                break;
            default:
                break;
        }
        return "";
    }
}
public enum ActionType
{
    Attack,
    Moving,
    Run,
    Dash,
    Idle,
}
