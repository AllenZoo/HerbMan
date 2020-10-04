using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Base : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float moveSpeed;

    public float GetHealth()
    {
        return health;
    }
    public void SubtractHealth(float num)
    {
        this.health -= num;
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
}
