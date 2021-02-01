using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy_Stipp_Controller))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy_Stipp_Movement : MonoBehaviour
{
    [SerializeField] public float escapeRange = 10;
    [SerializeField] public float aggroRange = 5;

    [SerializeField] private bool inMenu = false;

    private Rigidbody2D rb;
    internal Enemy_Stipp_Controller controller;

    private Transform player;
    private float moveSpeed;

    [SerializeField] private float jumpAnimTime;
    public bool isJumping;
    private Vector3 jumpDir;

    public bool isFollowing;

    private void Awake()
    {
        
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<Enemy_Stipp_Controller>();
        controller.stats = GetComponent<Enemy_Base>();
        moveSpeed = controller.stats.GetMoveSpeed();
    }

    private void FixedUpdate()
    {
        HandleJumping();
    }

    private void Update()
    {
        //Jitters if put into Fixed Update
        HandleFollowing();
    }

    #region Idle
    public void Idle()
    {
        rb.velocity = new Vector2(0, 0);
        isJumping = false;
        isFollowing = false;
    }
    #endregion

    #region Jump
    public void Jump()
    {
        var tempDir = (player.transform.position - this.transform.position).normalized;
        SetJumpDir(tempDir);
        StartCoroutine(JumpTimer(0));
    }
    public void Jump(float transitionTime)
    {
        var tempDir = (player.transform.position - this.transform.position).normalized;
        SetJumpDir(tempDir);
        StartCoroutine(JumpTimer(transitionTime));
    }
    public IEnumerator JumpTimer(float transitionTime)
    {
        Debug.Log("In jump timer");
        //controller.animatorController.ChangeState(Enemy_Stipp_Animation.ActionState.Frozen);
        yield return new WaitForSeconds(transitionTime);
        isJumping = true;
        yield return new WaitForSeconds(jumpAnimTime);
        isJumping = false;
    }
    public void SetJumpDir(Vector3 dir)
    {
        jumpDir = dir;
    }
    private void HandleJumping()
    {
        if (isJumping)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, this.transform.position + jumpDir, moveSpeed * Time.deltaTime);
        }
    }

    #endregion

    #region Follow
    public void Follow()
    {
        StartCoroutine(FollowTimer(0));
    }
    public void Follow(float transitionTime)
    {
        StartCoroutine(FollowTimer(transitionTime));
    }
    public IEnumerator FollowTimer(float transitionTime)
    {
        isFollowing = false;
        yield return new WaitForSeconds(transitionTime);
        isFollowing = true;
    }
    private void HandleFollowing()
    {
        if (isFollowing)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }
    #endregion
}
