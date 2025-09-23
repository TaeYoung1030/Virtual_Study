using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myPlayerFire : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform SpawnPos;
    [SerializeField] float coolTime = 3f;

    [SerializeField]
    int maxBullet = 10;
    int currentBullet = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentBullet = maxBullet;
        Debug.Log(currentBullet);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && currentBullet <= 0)
        {
            currentBullet--;
          
            
            //ÃÑ¾Ë »ý¼º
            GameObject prefabBullet = Instantiate(bullet, SpawnPos.position, transform.rotation);
            //ÃÑ¾Ë¹ß»ç
            prefabBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 500.0f);
                Debug.Log("Bullet : " + currentBullet);
                Destroy(bullet, 5.0f);
           

        }
    }
    public void ReloadBullet()
    {
        currentBullet = maxBullet;
    }

    public void SetCurrentBullet(int currentBullet)
    {
        this.currentBullet = currentBullet;
    }

    public int GetCurrentBullet()
    {
        return currentBullet;
    }
}
