using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class Collectable: MonoBehaviour
{
    //public delegate void Collect();
    public delegate void CollectFunction(Player inventory);
    public CollectFunction curFunc;

    public void SetCollectFunction(CollectFunction func)
    {
        curFunc = func;
    }
    public void Collect(Player player)
    {
        curFunc(player);
    }
}
