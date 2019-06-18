using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NPCControler : NetworkBehaviour
{
    [SyncVar] public int Phe;
    public GameObject PheDich;

    // Start is called before the first frame update
    void Start()
    {
    }



    // Update is called once per frame
    void Update()
    {
    }
}
