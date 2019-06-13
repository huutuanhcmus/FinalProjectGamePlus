using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.gameObject.tag);
    //    /*if(collision.gameObject.tag == "Player")
    //        Destroy(gameObject);*/
    //    Destroy(gameObject);
    //}

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
