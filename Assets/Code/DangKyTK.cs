using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DangKyTK : NetworkManager
{
    public void StartupHost()
    {
        SetPort();
        StartHost(); //Unity method
    }

    public void JoinGame()
    {
        SetIPAddress();
        SetPort();
        StartClient(); //Unity method
    }

    void SetIPAddress()
    {
        string ipAddress = GameObject.Find("InputFieldIPAddress").transform.FindChild("Text").GetComponent<Text>().text;
        networkAddress = ipAddress;
    }

    void SetPort()
    {
        networkPort = 4444;
    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            GameObject.Find("ButtonStartHost").GetComponent<Button>().onClick.AddListener(StartupHost);
            GameObject.Find("ButtonJoinGame").GetComponent<Button>().onClick.AddListener(JoinGame);
        }

        else
        {
            GameObject.Find("ButtonDisconnect").GetComponent<Button>().onClick.AddListener(StopHost); //Unity method
        }
    }
}
