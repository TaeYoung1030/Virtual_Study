using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myPlayerFire : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform SpawnPos;

    [SerializeField] float coolTime = 3f;

    float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > coolTime)
        {
        //ÃÑ¾Ë »ý¼º
            GameObject prefabBullet = Instantiate(bullet,SpawnPos.position,transform.rotation);
        //ÃÑ¾Ë¹ß»ç
            prefabBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 500.0f);
            currentTime = 0;
        }
    }
}
