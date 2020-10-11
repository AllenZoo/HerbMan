using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stipp_Movement : MonoBehaviour
{
    public Transform player;
    [SerializeField] float moveSpeed = 4;
    [SerializeField] float escapeRange = 10;
    [SerializeField] float aggroRange = 5;

    private float dist;
    private bool isAggro;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        isAggro = false;
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
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            if (dist >= escapeRange)
            {
                isAggro = false;
            }
        }
    }
}
