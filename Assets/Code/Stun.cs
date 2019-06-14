using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Stun : NetworkBehaviour
{
    [SyncVar] public int Phe;
    public float time;
    public float speedFunc;
    //public Transform spawn;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, time);
    }

    //private void Update()
    //{
    //    gameObject.GetComponent<Rigidbody>().velocity = spawn.forward * 6;
    //}

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        Debug.Log(other.GetComponent<PlayerController>().Phe);
        if (other.tag == "Player" && other.GetComponent<PlayerController>().Phe != Phe)
        {
            Debug.Log("1");
            var hit = other.gameObject;
            var stun = hit.GetComponent<PlayerController>();
            if (stun != null)
            {
                Debug.Log("2");
                stun.CmdStunPlayer(speedFunc);
            }
            Destroy(gameObject);
        }
    }
}
