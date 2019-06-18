using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DameLogo : MonoBehaviour
{
    public RawImage testImage;
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
            if (Input.GetKeyDown(KeyCode.F3) && mainChar.GetComponent<PlayerController>().Ready == true)
            {
                mainChar.GetComponent<PlayerController>().CmdChuyenDame();
                testImage.enabled = false;
                //GetComponent<DameLogo>().enabled = false;
                //DoiPhuong.GetComponent<BuffLogo>().enabled = false;
            }
            if (Input.GetKeyDown(KeyCode.F4) && mainChar.GetComponent<PlayerController>().Ready == true)
            {
                testImage.enabled = true;
            }
        }
    }
}
