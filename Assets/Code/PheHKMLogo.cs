using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PheHKMLogo : MonoBehaviour
{
    // Start is called before the first frame update
    public RawImage testImage;
    public Transform HKMPos;
    public GameObject DoiPhuong;
    // Update is called once per frame
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
        else
        {
            if (Input.GetKeyDown(KeyCode.F1) && mainChar.GetComponent<PlayerController>().Ready == true)
            {
                mainChar.GetComponent<PlayerController>().CmdHKM();
                //mainChar.GetComponent<Transform>().position = HKMPos.position;
                //testImage.enabled = false;
                //GetComponent<PheHKMLogo>().enabled = false;
                //DoiPhuong.GetComponent<PheANCLogo>().enabled = false;
            }
            /*if (Input.GetKeyDown(KeyCode.F2))
            {
                Debug.Log("vvvvvv");
                testImage.enabled = true;
            }*/
            if (mainChar.GetComponent<PlayerController>().Phe == 1)
            {
                testImage.enabled = false;
                GetComponent<RawImage>().enabled = true;
            }
        }
    }
}
