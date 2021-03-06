﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Base : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float collisionDamage;
    [SerializeField] private float projectileDamage;
    [SerializeField] private float knockbackAmount;
    [SerializeField] private int expValue;

    public float GetHealth()
    {
        return health;
    }
    public void TakeDamage(float num)
    {
        this.health -= num;

        if(health <= 0)
        {
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().level.AddExp(expValue);
        }
    }
    public void TakeDamage(float num, string tagOfDamager)
    {
        this.health -= num;

        if(health <= 0)
        {
            Destroy(gameObject);
            if(tagOfDamager == "Player")
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().level.AddExp(expValue);
            }
        }
    }

    public void AddHealth(float num)
    {
        this.health += num;
    }
    public void SetHealth(float num)
    {
        this.health = num;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public void SubtractMoveSpeed(float num)
    {
        this.moveSpeed -= num;
    }
    public void AddMoveSpeed(float num)
    {
        this.moveSpeed += num;
    }
    public void SetMoveSpeed(float num)
    {
        this.moveSpeed = num;
    }

    public float GetCollsionDamage()
    {
        return collisionDamage;
    }
    public void SubtractCollisionDamage(float num)
    {
        collisionDamage -= num;
    }
    public void AddCollisionDamage(float num)
    {
        collisionDamage += num;
    }
    public void SetCollisionDamage(float num)
    {
        collisionDamage = num;
    }

    public float GetProjectileDamage()
    {
        return projectileDamage;
    }
    public void SubtractProjectileDamage(float num)
    {
        projectileDamage -= num;
    }
    public void AddProjectileDamage(float num)
    {
        projectileDamage += num;
    }
    public void SetProjectileDamage(float num)
    {
        projectileDamage = num;
    }

    public float GetKnockbackAmount()
    {
        return knockbackAmount;
    }
}
