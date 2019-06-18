using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PheANCLogo : MonoBehaviour
{
    public RawImage testImage;
    public Transform ANCPos;
    public GameObject DoiPhuong;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            testImage.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
            {
                if (go.name == "MainChar")
                {
                    go.GetComponent<PlayerController>().CmdANC();
                    go.GetComponent<Transform>().position = ANCPos.position;
                    break;
                }
            }
            testImage.enabled = false;
            GetComponent<PheANCLogo>().enabled = false;
            DoiPhuong.GetComponent<PheHKMLogo>().enabled = false;
        }
    }
}
