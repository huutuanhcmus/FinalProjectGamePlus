﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class buffManaSingle : NetworkBehaviour
{
    [SyncVar] public int Phe;
    public float time;
    public int Mana;
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
            var health = hit.GetComponent<Mancharacter>();
            if (health != null)
            {
                Debug.Log("bbb");
                health.CmdPushMana(Mana);
            }
            Destroy(gameObject);
        }
    }
}
