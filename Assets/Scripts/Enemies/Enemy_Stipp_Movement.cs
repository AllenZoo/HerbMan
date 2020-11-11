using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stipp_Movement : MonoBehaviour
{
    [SerializeField] private float escapeRange = 10;
    [SerializeField] private float aggroRange = 5;
    [SerializeField] private bool inMenu = false;

    private float moveSpeed;

    private Transform player;
    private Transform lastPlayerPosition;
    private Enemy_Stipp_Animation stippAnimation;

    private float dist;
    private bool isAggro;
    private bool canJump;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        lastPlayerPosition = player.transform;

        stippAnimation = GetComponent<Enemy_Stipp_Animation>();
        moveSpeed = GetComponent<Enemy_Base>().GetMoveSpeed();
        isAggro = false;
        canJump = true;
    }

    private void Update()
    {
        dist = Vector2.Distance(transform.position, player.position);
        if (dist <= aggroRange && !isAggro)
        {
            isAggro = true;

        }
        if (isAggro)
        {
            if (canJump)
            {
                StartCoroutine(Jump());
            }

            if (dist >= escapeRange)
            {
                isAggro = false;
            }
        }
    }

    private IEnumerator Jump()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        stippAnimation.StippJumpAnim(true);

        yield return new WaitForSeconds(1);

        stippAnimation.StippJumpAnim(false);
        StopAllCoroutines();

        StartCoroutine(StartCooldown("Jump", 2));
    }
    private IEnumerator StartCooldown(string action, float seconds)
    {
        ActionHandler(action, false);
        Debug.Log(canJump);
        yield return new WaitForSeconds(seconds);
        ActionHandler(action, true);
        Debug.Log(canJump);
    }
    private void ActionHandler(string action, bool state)
    {
        switch (action)
        {
            case "Jump":
                canJump = state;
                break;
        }
    }
}
