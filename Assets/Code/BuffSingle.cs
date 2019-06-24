﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BuffSingle : NetworkBehaviour
{
    [SyncVar] public int Phe;
    [SyncVar] public int lv;
    public float time;
    public int HPHealth;
    //public Transform spawn;

    private void Start()
    {
        Destroy(gameObject, time);
        /*foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
        {
            if (go.name == "MainChar")
            {
                if (go.GetComponent<PlayerController>().Phe != Phe)
                {
                    GetComponent<Transform>().GetChild(0).GetComponent<ParticleSystem>().startColor = Color.red;
                    GetComponent<Transform>().GetComponent<ParticleSystem>().startColor = Color.red;
                    break;
                }
            }
        }*/
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
        if (other.tag == "Player" && other.GetComponent<PlayerController>().Phe == Phe)
        {
            var hit = other.gameObject;
            var health = hit.GetComponent<Health>();
            if (health != null)
            {
                Debug.Log("bbb");
                health.CmdPushHealth(HPHealth);
            }
            Destroy(gameObject);
        }
        if(other.tag == "NPC" && other.GetComponent<NPCControler>().Phe == Phe)
        {
            var hit = other.gameObject;
            var health = hit.GetComponent<HealthNPC>();
            float dameTemp = 0;
            dameTemp = HPHealth * (Mathf.Pow(1.1f, lv));
            if (health != null)
            {
                health.CmdPushHealth((int)dameTemp);
            }
            Destroy(gameObject);
        }
    }
}
