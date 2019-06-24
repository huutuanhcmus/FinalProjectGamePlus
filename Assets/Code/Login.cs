using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField ID;
    public InputField PASS;
    public GameObject mainChar;
    void Update()
    {
        if (mainChar == null)
        {
            foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
            {
                if (go.name == "MainChar")
                {
                    mainChar = go;
                    break;
                }
            }
        }
    }

    public void LoginCh()
    {
            mainChar.GetComponent<PlayerController>().LoginChar(ID.text, PASS.text);
    }
}
