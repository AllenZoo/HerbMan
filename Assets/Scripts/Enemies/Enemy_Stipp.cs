using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stipp : MonoBehaviour
{
    private Animator animator;
    private Sprite sprite;
    private SpriteRenderer spriteRenderer;

    private float health;
    private float moveSpeed;

    private Enemy_Base enemyBase;
   

    private void Awake()
    {
        //Visual
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;

        //Base (Stores stats)
        enemyBase = GetComponent<Enemy_Base>();
        RefreshStats();
    }


    
    private void RefreshStats()
    {
        health = enemyBase.GetHealth();
        moveSpeed = enemyBase.GetMoveSpeed();
    }

}
