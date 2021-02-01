using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Gunner_Movement : MonoBehaviour
{
    [SerializeField] private float escapeRange = 10;
    [SerializeField] private float aggroRange = 5;

    [Header("Shooting range has to be smaller than escape range")]
    [SerializeField] private float shootRange = 7;

    private float moveSpeed;


    private Transform player;
    private float dist;
    private bool isAggro;
    private bool isReloaded;
    private bool canMove;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        moveSpeed = GetComponent<Enemy_Base>().GetMoveSpeed();
        isAggro = false;
        canMove = false;
        isReloaded = true;
    }

    private void Update()
    {
        dist = Vector2.Distance(transform.position, player.position);
        if (dist <= aggroRange && !isAggro)
        {
            isAggro = true;
            canMove = true;
        }
        if (isAggro)
        {
            if(dist <= shootRange && isReloaded == true)
            {
               StartCoroutine(Shoot());        
            }
            if (canMove)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            }

            if (dist >= escapeRange)
            {
                isAggro = false;
            }
        }
    }

    private IEnumerator Shoot()
    {
        isReloaded = false;
        GetComponent<Enemy_Gunner_Shooting>().FireBullet();
        canMove = false;

        yield return new WaitForSeconds(1);
        canMove = true;

        yield return new WaitForSeconds(3);
        isReloaded = true;

    }
    //private void FireBullet()
    //{
    //    Debug.Log("Firing bullet");
    //    GameObject bullet = GM_ObjectPooler.Instance.GetPooledObjects("Gunner_Bullet");
    //    if (bullet != null)
    //    {
    //        bullet.transform.position = this.transform.position;
    //        bullet.transform.rotation = this.transform.rotation;
    //        bullet.SetActive(true);

    //        Rigidbody2D rb_Bullet = bullet.GetComponent<Rigidbody2D>();
    //        Debug.Log("Bullet fired!");
    //    }
    //}
}
