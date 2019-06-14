using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour
{
    [SyncVar]public int Phe;
    public float time;
    public int dame;
    //public Transform spawn;

    private void Start()
    {
        Destroy(gameObject, time);
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.gameObject.tag);
    //    /*if(collision.gameObject.tag == "Player")
    //        Destroy(gameObject);*/
    //    Destroy(gameObject);
    //}

    //private void Update()
    //{
    //    gameObject.GetComponent<Rigidbody>().velocity = spawn.forward * 6;
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.GetComponent<PlayerController>().Phe != Phe)
        {
            var hit = other.gameObject;
            var health = hit.GetComponent<Health>();
            if (health != null)
            {
                Debug.Log("bbb");
                health.CmdTakeDame(dame);
            }
            Destroy(gameObject);
        }
    }


}
