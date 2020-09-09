using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    public Item item;

    [SerializeField] private bool isRespawnable;
    [SerializeField] private bool isVein;
    private void Start()
    {
        if (!isVein)
        {
            ItemWorld.SpawnItemWorld(transform.position, item);
            if (!isRespawnable)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        if (isVein)
        {

        }
    }
}
