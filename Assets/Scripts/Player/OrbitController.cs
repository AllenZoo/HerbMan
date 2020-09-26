using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitController : MonoBehaviour
{
    public float speed = 5f;


    private Transform player;
    private Player_Movement playerMovement;

    private void Start()
    {
        player = transform.parent;
        playerMovement = player.GetComponent<Player_Movement>();
    }
    private void FollowMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }

    

    private void Update()
    {
        FollowMouse();

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("right click!");
        }
        
        if (Input.GetMouseButton(0))
        {
            //left click
           
        }
        if (Input.GetMouseButtonUp(0))
        {
            
        }
    }
}
