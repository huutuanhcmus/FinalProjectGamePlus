using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BuffAOE : NetworkBehaviour
{
    [SyncVar] public int Phe;
    public float time;
    public int HPHealth;
    public float speed;
    public float timeStun;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, time);
        /*foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
        {
            if (go.name == "MainChar")
            {
                if (go.GetComponent<PlayerController>().Phe != Phe)
                {
                    GetComponent<Transform>().GetChild(0).GetComponent<ParticleSystem>().startColor = Color.red;
                    GetComponent<Transform>().GetChild(1).GetComponent<ParticleSystem>().startColor = Color.red;
                    break;
                }
            }
        }*/
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.GetComponent<PlayerController>().Phe == Phe)
        {
            Debug.Log(Phe);
            Debug.Log(other.GetComponent<PlayerController>().Phe);
            var hit = other.gameObject;
            var health = hit.GetComponent<Health>();
            if (health != null)
            {
                Debug.Log("222");
                health.CmdPushHealth(HPHealth);
                hit.GetComponent<PlayerController>().CmdStunPlayerSlow(speed);
            }
        }
        if(other.tag == "NPC" && other.GetComponent<NPCControler>().Phe == Phe)
        {
            var hit = other.gameObject;
            var health = hit.GetComponent<HealthNPC>();
            if (health != null)
            {
                health.CmdPushHealth(HPHealth);
            }
        }
    }
}
