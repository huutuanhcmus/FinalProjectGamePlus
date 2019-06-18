using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    public Thread countTimeThread;
    public Thread countTotalTimeThread;
    public GameObject obANCLogo;
    public GameObject obHKMLogo;
    // Start is called before the first frame update
    [SyncVar] public int ANCTime = 0;
    [SyncVar] public int HKMTime = 0;
    public bool flag = false;
    public bool flagTotal = false;
    public int time;
    public int totalTime;
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
        countTimeThread = new Thread(new ThreadStart(countTime));
        countTimeThread.Start();
        countTotalTimeThread = new Thread(new ThreadStart(countTimeTotal));
        countTotalTimeThread.Start();
    }

    private void Update()
    {
        if (flag)
        {
            flag = false;
            CmdPushTime();
            HKMTime -= 4;
            ANCTime -= 4;
        }
        if (flagTotal)
        {
            countTimeThread.Abort();
            countTotalTimeThread.Abort();
            flagTotal = false;
            Debug.Log("abcdef");
            if (HKMTime > ANCTime)
            {
                var temp = (GameObject)Instantiate(obHKMLogo);
                NetworkServer.Spawn(obHKMLogo);
            }
            else if(ANCTime > HKMTime)
            {
                var temp = (GameObject)Instantiate(obANCLogo);
                NetworkServer.Spawn(obANCLogo);
            }
        }
    }

    [Command]
    void CmdPushTime()
    {
        foreach (GameObject NPC in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
        {
            if (NPC.tag == "NPC")
            {
                Debug.Log(NPC.name);
                if (NPC.GetComponent<NPCControler>().Phe == 1)
                {
                    HKMTime++;
                }
                else
                {
                    ANCTime++;
                }
            }
            else if (NPC.tag == "NPCMain")
            {
                Debug.Log(NPC.name);
                if (NPC.GetComponent<NPCControler>().Phe == 1)
                {
                    HKMTime += 3;
                }
                else
                {
                    ANCTime += 3;
                }
            }
        }
    }
    void countTime()
    {
        while (true)
        {
            Debug.Log("------////--");
            Thread.Sleep(time * 1000);
            flag = true;
        }
    }

    void countTimeTotal()
    {
        while (true)
        {
            
            Thread.Sleep(totalTime * 1000);
            flagTotal = true;
            Debug.Log("------////--");
        }
    }
}
