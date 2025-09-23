using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int enemyHealth = 5;

    string bullet_Name = "Bullet";
    private void Start()
    {
        Debug.Log("First Enemy Health : " + enemyHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(bullet_Name))
        {
            enemyHealth--;
            if (enemyHealth <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Destroy Enemy");
            }
            Debug.Log("Enemy Health : " + enemyHealth);
            Destroy(collision.gameObject);

        }
    }

}
