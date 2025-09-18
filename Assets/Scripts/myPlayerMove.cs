using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myPlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 0.05f;
    float moveX;
    float moveZ;
    float moveY;

    Transform playerPosition;
    Vector3 movement;

    void Start()
    {
        //moveZ = 0.0f;
       // playerPosition = GetComponent<Transform>();
        //movement = new Vector3(0,1,0);
        //transform.position = movement;
    }


    void Update()
    {
        // movement.x += speed;
        //moveX = Input.GetAxis("Horizontal");
        //moveZ = Input.GetAxis("Vertical");
        //moveY = Input.GetAxis("Jump");
        //movement = new Vector3(moveX,0,moveZ);
        //playerPosition.position += movement * speed;
        movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;
        }
        movement.Normalize();
        transform.Translate(movement * speed,Space.World);
        //vector √ ±‚»≠ 

        transform.LookAt(transform.position + movement);
    }
}
