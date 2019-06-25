using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;

public class FlagNPC : NetworkBehaviour
{
    public Transform posHKM;
    public Transform posANC;
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
    public GameObject obHoa;
    // Start is called before the first frame update
    [SyncVar] public int ANCTime = 0;
    [SyncVar] public int HKMTime = 0;
    public bool flag = false;
    public bool flagTotal = false;
    public int time;
    public int totalTime;
    public int numberPlayer = 4;
    public bool start = false;
    public List<GameObject> listPlayer;
    public int numberANCPlayer = 0;
    public int numberHKMPlayer = 0;
    public List<GameObject> listPlayerHKM;
    public List<GameObject> listPlayerANC;
    string filename = "dataplayer.gd";
    public override void OnStartServer()
    {
        base.OnStartServer();
        listPlayer = new List<GameObject>();
        listPlayerHKM = new List<GameObject>();
        listPlayerANC = new List<GameObject>();
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
        if (start)
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
                    NetworkServer.Spawn(temp);
                    Win(1);
                }
                else if (ANCTime > HKMTime)
                {
                    var temp = (GameObject)Instantiate(obANCLogo);
                    NetworkServer.Spawn(temp);
                    Win(2);
                }
                else
                {
                    var temp = (GameObject)Instantiate(obHoa);
                    NetworkServer.Spawn(temp);
                    Win(0);
                }
                saveDataChar();
            }
        }
        else
        {
            listPlayer.Clear();
            listPlayerANC.Clear();
            listPlayerHKM.Clear();
            if(NetworkServer.connections.Count == numberPlayer + 1)
            {
                foreach (GameObject Player in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
                {
                    if (Player.tag == "Player" && !listPlayer.Contains(Player))
                    {
                        listPlayer.Add(Player);
                    }
                }
                foreach (GameObject Player in listPlayer)
                {
                    Debug.Log("Do day roi");
                    if (Player.GetComponent<PlayerController>().Phe == 1 && !listPlayerHKM.Contains(Player))
                    {
                        listPlayerHKM.Add(Player);
                    }
                    else if (Player.GetComponent<PlayerController>().Phe == 2 && !listPlayerANC.Contains(Player))
                    {
                        listPlayerANC.Add(Player);
                    }
                }
                if(listPlayerHKM.Count > (numberPlayer / 2))
                {
                    for (int i = numberPlayer / 2; i < listPlayerHKM.Count; i++)
                    {
                        Debug.Log(listPlayerHKM.Count);
                        //RpcChuyenPhe(listPlayerHKM[i], 2);
                        listPlayerHKM[i].GetComponent<PlayerController>().Phe = 2;
                        listPlayerANC.Add(listPlayerHKM[i]);
                        listPlayerHKM.RemoveAt(i);
                        i--;
                    }
                }
                if (listPlayerANC.Count > (numberPlayer / 2))
                {

                    for (int i = numberPlayer / 2; i < listPlayerANC.Count; i++)
                    {
                        Debug.Log(listPlayerANC.Count);

                        //RpcChuyenPhe(listPlayerANC[i], 1);
                        listPlayerANC[i].GetComponent<PlayerController>().Phe = 1;
                        listPlayerHKM.Add(listPlayerANC[i]);
                        listPlayerANC.RemoveAt(i);
                        i--;
                    }
                }
                if(listPlayerANC.Count == numberPlayer/2 && listPlayerHKM.Count == numberPlayer / 2)
                {
                    for(int i=0;i< listPlayerHKM.Count; i++)
                    {
                        listPlayerHKM[i].GetComponent<PlayerController>().Ready = false;
                        listPlayerHKM[i].GetComponent<Health>().RpcMoveTo(posHKM.position);
                    }
                    for (int i = 0; i < listPlayerANC.Count; i++)
                    {
                        listPlayerANC[i].GetComponent<PlayerController>().Ready = false;
                        listPlayerANC[i].GetComponent<Health>().RpcMoveTo(posANC.position);
                    }
                    /*Debug.Log("do dc day r");
                    foreach (GameObject Player in listPlayer)
                    {
                        Debug.Log("cbbb");
                        Player.GetComponent<PlayerController>().Ready = false;
                        if (Player.GetComponent<PlayerController>().Phe == 1)
                        {
                            Debug.Log("cbbb1");
                            //Player.GetComponent<Transform>().position = posHKM.position;
                            RpcMoveTo(Player, posHKM.position);
                        }
                        else if (Player.GetComponent<PlayerController>().Phe == 2)
                        {
                            Debug.Log("cbbb2");
                            //Player.GetComponent<Transform>().position = posANC.position;
                            RpcMoveTo(Player, posANC.position);
                            
                        }
                    }*/
                    start = true;
                }
            }
        }
    }

    [ClientRpc]
    void RpcMoveTo(GameObject ob, Vector3 pos)
    {
        Debug.Log("bccc");
        ob.GetComponent<Transform>().position = pos; //this will run in all clients
    }
    [ClientRpc]
    void RpcChuyenPhe(GameObject player, int phe)
    {
        player.GetComponent<PlayerController>().Phe = phe;
    }

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

    //[ClientRpc]
    public void Win(int PheThang)
    {
        if(PheThang == 1)
        {
            foreach (GameObject Player in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
            {
                if (Player.tag == "Player")
                {
                    if (Player.GetComponent<PlayerController>().Phe == 1)
                    {
                        Player.GetComponent<PlayerController>().ex += 50;
                        if (Player.GetComponent<PlayerController>().ex >= (int)(100 * Mathf.Pow(1.1f, Player.GetComponent<PlayerController>().lv)))
                        {
                            Player.GetComponent<PlayerController>().ex = Player.GetComponent<PlayerController>().ex - (int)(500 * Mathf.Pow(1.1f, Player.GetComponent<PlayerController>().lv));
                            Player.GetComponent<PlayerController>().lv += 1;
                        }
                    }
                    else
                    {
                        Player.GetComponent<PlayerController>().ex += 20;
                        if (Player.GetComponent<PlayerController>().ex >= (int)(100 * Mathf.Pow(1.1f, Player.GetComponent<PlayerController>().lv)))
                        {
                            Player.GetComponent<PlayerController>().ex = Player.GetComponent<PlayerController>().ex - (int)(500 * Mathf.Pow(1.1f, Player.GetComponent<PlayerController>().lv));
                            Player.GetComponent<PlayerController>().lv += 1;
                        }
                    }
                } 
            }
        }
        else if (PheThang == 2)
        {
            foreach (GameObject Player in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
            {
                if (Player.tag == "Player")
                {
                    if (Player.GetComponent<PlayerController>().Phe == 1)
                    {
                        Player.GetComponent<PlayerController>().ex += 20;
                        if (Player.GetComponent<PlayerController>().ex >= (int)(100 * Mathf.Pow(1.1f, Player.GetComponent<PlayerController>().lv)))
                        {
                            Player.GetComponent<PlayerController>().ex = Player.GetComponent<PlayerController>().ex - (int)(500 * Mathf.Pow(1.1f, Player.GetComponent<PlayerController>().lv));
                            Player.GetComponent<PlayerController>().lv += 1;
                        }
                    }
                    else
                    {
                        Player.GetComponent<PlayerController>().ex += 50;
                        if (Player.GetComponent<PlayerController>().ex >= (int)(100 * Mathf.Pow(1.1f, Player.GetComponent<PlayerController>().lv)))
                        {
                            Player.GetComponent<PlayerController>().ex = Player.GetComponent<PlayerController>().ex - (int)(500 * Mathf.Pow(1.1f, Player.GetComponent<PlayerController>().lv));
                            Player.GetComponent<PlayerController>().lv += 1;
                        }
                    }
                }
            }
        }
        else
        {
            foreach (GameObject Player in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
            {
                if (Player.tag == "Player")
                {

                    Player.GetComponent<PlayerController>().ex += 35;
                    if (Player.GetComponent<PlayerController>().ex >= (int)(100 * Mathf.Pow(1.1f, Player.GetComponent<PlayerController>().lv)))
                    {
                        Player.GetComponent<PlayerController>().ex = Player.GetComponent<PlayerController>().ex - (int)(500 * Mathf.Pow(1.1f, Player.GetComponent<PlayerController>().lv));
                        Player.GetComponent<PlayerController>().lv += 1;
                    }
                }
            }
        }
    }

    void saveDataChar()
    {
        string[] readText = File.ReadAllLines(Application.persistentDataPath + "/" + filename);
        foreach (GameObject Player in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
        {
            if (Player.tag == "Player")
            {
                for (int i = 0; i < readText.Length; i += 4)
                {
                    if (readText[i] == Player.GetComponent<PlayerController>().id)
                    {
                        readText[i + 2] = Player.GetComponent<PlayerController>().lv.ToString();
                        readText[i + 3] = Player.GetComponent<PlayerController>().ex.ToString();
                        break;
                    }
                }
            }
        }
        File.WriteAllLines(Application.persistentDataPath + "/" + filename, readText);
    }
}
