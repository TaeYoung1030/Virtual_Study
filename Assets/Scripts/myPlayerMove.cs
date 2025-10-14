using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class myPlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float isRunning = 1.0f;
    [SerializeField] float runSpeed = 2.0f;
    [SerializeField] float lookSpeed = 0.1f;
    [SerializeField] float jumpSpeed = 200f;

    [SerializeField] public float maxHP = 10;

    [SerializeField] public float currentCoolTime;
    public float HP;
    public float skillCoolTime = 10f;
    public float currentRunningGaze;
    public float maxRunningGaze;
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
        HP = maxHP;
        currentRunningGaze = maxRunningGaze;
    }


    void Update()
    {
        if (currentCoolTime >= 10f)
            currentCoolTime = 10f;
        currentCoolTime += Time.deltaTime;
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

        //vector �ʱ�ȭ 
        //movement.magnitude�� ���ؼ� ã�ƺ��� 
        if (Input.GetKeyDown(KeyCode.LeftShift) && currentRunningGaze >= 2.0)
        {
            isRunning = runSpeed;
            
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = 1.0f;
            //currentRunningGaze += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentRunningGaze -= Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.Space)&&currentCoolTime > skillCoolTime)
        {
            currentCoolTime = 0f;
            DestroyBullet();
        }
        animatior.SetBool("onGround", isGround);
        if (Input.GetKeyDown(KeyCode.LeftControl) && isGround)
        {

            animatior.SetTrigger("Jump");
            rb.AddForce(Vector3.up * jumpSpeed);

        }
        movement.Normalize();
        if (movement.magnitude > 0.1f)
        {
            //���� �ϳ� �� ���-> ȸ���� ����
            Quaternion q = Quaternion.LookRotation(movement);
            //������ ����, ������ ����
            transform.rotation = Quaternion.Lerp(transform.rotation, q, lookSpeed);
            //transform.LookAt(transform.position + movement);
        }


        transform.Translate(movement * Time.deltaTime *speed * isRunning, Space.World);
        animatior.SetFloat("Movement", movement.magnitude * isRunning);

    }

    void DestroyBullet()
    {
        GameObject[] bullets;
        bullets = GameObject.FindGameObjectsWithTag("Bullet");

        foreach(GameObject bullet in bullets)
            Destroy(bullet);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            isGround = true;
        }

        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            HP--;
        }
        if(collision.gameObject.CompareTag("Heal"))
        {
            Destroy(collision.gameObject);
            HP += 3;
            if(HP >=maxHP) { HP = maxHP; }
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
