using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stipp : MonoBehaviour
{
    private float health;
    private float moveSpeed;

    private Enemy_Base enemyBase;
   

    private void Awake()
    {
        enemyBase = GetComponent<Enemy_Base>();
        health = enemyBase.GetHealth();
        moveSpeed = enemyBase.GetMoveSpeed();
    }
    


}
