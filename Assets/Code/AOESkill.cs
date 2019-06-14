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
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, time);
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
                Debug.Log("222");
                health.CmdTakeDame(dame);
                stun.CmdStunPlayerSlow(speed);
            }
        }
    }
}
