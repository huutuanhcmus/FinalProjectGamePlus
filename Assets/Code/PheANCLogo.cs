using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PheANCLogo : MonoBehaviour
{
    public RawImage testImage;
    public Transform ANCPos;
    public GameObject DoiPhuong;
    public GameObject mainChar;

    // Update is called once per frame
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
        else
        {
            /*if (Input.GetKeyDown(KeyCode.F1))
            {
                testImage.enabled = true;
            }*/
            if (Input.GetKeyDown(KeyCode.F2) && mainChar.GetComponent<PlayerController>().Ready == true)
            {
                mainChar.GetComponent<PlayerController>().CmdANC();
                //mainChar.GetComponent<Transform>().position = ANCPos.position;
                //testImage.enabled = false;
                //GetComponent<PheANCLogo>().enabled = false;
                //testImage.enabled = false;
                //GetComponent<PheANCLogo>().enabled = false;
                //DoiPhuong.GetComponent<PheHKMLogo>().enabled = false;
            }
            if (mainChar.GetComponent<PlayerController>().Phe == 2)
            {
                testImage.enabled = false;
                GetComponent<RawImage>().enabled = true;
            }
        }
    }
}
