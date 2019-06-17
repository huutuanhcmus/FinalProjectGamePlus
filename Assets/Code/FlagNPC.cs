using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FlagNPC : NetworkBehaviour
{
    public List<GameObject> HKMFlagOb;
    public List<GameObject> ANCFlagOb;
    public List<Transform> HKMPos;
    public List<Vector3> scaleHKM;
    public List<Transform> ANCPos;
    public List<Vector3> scaleANC;
    public List<GameObject> HKMFlag;
    public List<GameObject> ANCFlag;
    // Start is called before the first frame update

    public override void OnStartServer()
    {
        base.OnStartServer();
        for (int i = 0; i < HKMPos.Count; i++)
        {
            HKMFlag.Add((GameObject)Instantiate(HKMFlagOb[i], HKMPos[i].position, HKMPos[i].rotation));
            NetworkServer.Spawn(HKMFlag[i]);
        }
        for (int i = 0; i < ANCPos.Count; i++)
        {
            ANCFlag.Add((GameObject)Instantiate(ANCFlagOb[i], ANCPos[i].position, ANCPos[i].rotation));
            NetworkServer.Spawn(ANCFlag[i]);
        }
    }
}
