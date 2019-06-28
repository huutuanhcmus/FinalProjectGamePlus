using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AOESkill : NetworkBehaviour
{
    [SyncVar] public int Phe;
    public float time;
    public int dame;
    public float speed;
    public float timeStun;
    public float lv;
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
                    GetComponent<Transform>().GetChild(1).GetComponent<ParticleSystem>().startColor = Color.red;
                    break;
                }
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.GetComponent<PlayerController>().Phe != Phe)
        {
            Debug.Log(Phe);
            Debug.Log(other.GetComponent<PlayerController>().Phe);
            var hit = other.gameObject;
            var health = hit.GetComponent<Health>();
            var stun = hit.GetComponent<PlayerController>();
            if (health != null && stun != null)
            {
                float dameTemp = 0;
                dameTemp = dame * (Mathf.Pow(1.1f, lv));
                Debug.Log("222");
                health.CmdTakeDame((int)dameTemp);
                stun.CmdStunPlayerSlow(speed);
            }
        }
        if (other.tag == "NPC" && other.GetComponent<NPCControler>().Phe != Phe)
        {
            var hit = other.gameObject;
            var health = hit.GetComponent<HealthNPC>();
            if (health != null)
            {
                health.CmdTakeDame(dame);
            }
        }
    }
}
