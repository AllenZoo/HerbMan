using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stipp : MonoBehaviour
{
    private Animator animator;
    private float health;
    private float moveSpeed;

    private Enemy_Base enemyBase;
   

    private void Awake()
    {
        animator = GetComponent<Animator>();

        enemyBase = GetComponent<Enemy_Base>();
        health = enemyBase.GetHealth();
        moveSpeed = enemyBase.GetMoveSpeed();
    }
    
    

}
