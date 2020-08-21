using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    public Item item;

    [SerializeField] private bool isRespawnable;

    private void Start()
    {
        ItemWorld.SpawnItemWorld(transform.position, item);
        if (!isRespawnable)
            Destroy(gameObject);
        else
            gameObject.SetActive(false);
    }
}
