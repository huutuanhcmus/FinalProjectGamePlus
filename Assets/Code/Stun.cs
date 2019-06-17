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
        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
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
        }
    }

    //private void Update()
    //{
    //    gameObject.GetComponent<Rigidbody>().velocity = spawn.forward * 6;
    //}

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
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
        if (other.tag == "NPC" && other.GetComponent<NPCControler>().Phe != Phe)
        {
            Destroy(gameObject);
        }
    }
}
