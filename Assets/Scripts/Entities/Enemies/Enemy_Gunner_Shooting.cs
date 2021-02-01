using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Gunner_Shooting : MonoBehaviour
{
    private GameObject player;
    private Transform bulletSource;
    private Vector2 directionToPlayer;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bulletSource = transform.Find("Gun");

        directionToPlayer = player.transform.position - bulletSource.transform.position;
    }
    public void FireBullet()
    {
        Debug.Log("Firing bullet");
        GameObject bullet = GM_ObjectPooler.Instance.GetPooledObjects("Gunner_Bullet");
        if (bullet != null)
        {
            bullet.transform.position = bulletSource.transform.position;
            bullet.transform.rotation = bulletSource.transform.rotation;
            bullet.SetActive(true);

            Rigidbody2D rb_Bullet = bullet.GetComponent<Rigidbody2D>();
            directionToPlayer = player.transform.position - bulletSource.transform.position;
            rb_Bullet.velocity = directionToPlayer;
            Debug.Log("Bullet fired!");
        }
    }
}
