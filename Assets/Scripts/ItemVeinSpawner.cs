using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVeinSpawner : MonoBehaviour
{
    public ItemVein itemVein;

    private void Start()
    {
        ItemWorld.SpawnItemVein(transform.position, itemVein);
    }
}
