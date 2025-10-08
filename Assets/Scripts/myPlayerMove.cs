using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class myPlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 0.05f;
    [SerializeField] float isRunning = 1.0f;
    [SerializeField] float runSpeed = 2.0f;
    [SerializeField] float lookSpeed = 0.1f;
    [SerializeField] float jumpSpeed = 200f;
    float moveX;
    float moveZ;
    float moveY;
    bool isGround = true;

    Transform playerPosition;
    Animator animatior;
    Rigidbody rb;
    Vector3 movement;

    void Start()
    {
        //moveZ = 0.0f;
        // playerPosition = GetComponent<Transform>();
        //movement = new Vector3(0,1,0);
        //transform.position = movement;
        animatior = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
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

        //vector �ʱ�ȭ 
        //movement.magnitude�� ���ؼ� ã�ƺ��� 
        if (movement.magnitude > 0.1f)
        {
            //���� �ϳ� �� ���-> ȸ���� ����
            Quaternion q = Quaternion.LookRotation(movement);
            //������ ����, ������ ����
            transform.rotation = Quaternion.Lerp(transform.rotation, q, lookSpeed);
            //transform.LookAt(transform.position + movement);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = runSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = 1.0f;
        }
        animatior.SetBool("onGround", isGround);
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {

            animatior.SetTrigger("Jump");
            rb.AddForce(Vector3.up * jumpSpeed);

        }


        transform.Translate(movement * speed * isRunning, Space.World);
        animatior.SetFloat("Movement", movement.magnitude * isRunning);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            isGround = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.CompareTag("ground"))
        {
            isGround = !isGround;
        }
    }


}
