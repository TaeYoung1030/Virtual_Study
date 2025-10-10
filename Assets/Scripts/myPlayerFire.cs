using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myPlayerFire : MonoBehaviour
{
    [SerializeField] Transform SpawnPos;

    [SerializeField] float CoolTime = 4f;
    [SerializeField] float fireSpeed = 300.0f;
    [SerializeField] int maxBullet = 10;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject healSphere;
    [SerializeField] GameObject player;

    int currentBullet = 0;
    float currentTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        currentBullet = maxBullet;
        CoolTime = Random.Range(2, 8);
        //Debug.Log(currentBullet);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.Space) && currentBullet >0)
        {
            currentBullet--;
                
            //ÃÑ¾Ë »ý¼º
            GameObject prefabBullet = Instantiate(bullet, SpawnPos.position, transform.rotation);
            //ÃÑ¾Ë¹ß»ç
            prefabBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 500.0f);
            Debug.Log("Last Bullet : " + currentBullet);

            Destroy(prefabBullet, 5.0f);
        
        }
        */
        currentTime += Time.deltaTime;
        if (currentTime > CoolTime)
        {
            currentTime = 0.0f;
            CoolTime = Random.Range(2, 8);
            int randomBullet = Random.Range(1, 11);
            GameObject prefab =null;
            if(randomBullet != 1)
            {
                prefab = InstantiatePrefabBullet(bullet);
                fireSpeed = 400f;
            }
            else
            {
                prefab = InstantiatePrefabBullet(healSphere);
                fireSpeed = 150f;
            }
            prefab.GetComponent<Rigidbody>().AddForce(transform.forward * fireSpeed);
            Destroy(prefab, 7.0f);
        }

        transform.LookAt(player.transform);

    }
    public void ReloadBullet()
    {
        currentBullet = maxBullet;
        //Debug.Log("Add Bullet : " + currentBullet);
    }

    GameObject InstantiatePrefabBullet(GameObject go)
    {
        return Instantiate(go, SpawnPos.position, transform.rotation);

    }

}
