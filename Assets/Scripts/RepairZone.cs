using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairZone : MonoBehaviour
{
    //myPlayerFire myPlayerFire;
    private void Start()
    {
        //myPlayerFire = FindFirstObjectByType<myPlayerFire>();
    }
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger Enter");
        //myPlayerFire.SetCurrentBullet(myPlayerFire.maxBullet);
        //Debug.Log(myPlayerFire.GetCurrentBullet());
        //other.CompareTag("tower")
        //other.gameObject.
        if(other.CompareTag("Tower"))
        {
            other.GetComponent<myPlayerFire>().ReloadBullet();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Trigger Exit");
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Trigger stay");
    }
}
