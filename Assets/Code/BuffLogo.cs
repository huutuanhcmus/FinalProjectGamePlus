using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffLogo : MonoBehaviour
{
    public RawImage testImage;
    public GameObject DoiPhuong;
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
            if (Input.GetKeyDown(KeyCode.F3) && mainChar.GetComponent<PlayerController>().Ready == true)
            {
                testImage.enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.F4) && mainChar.GetComponent<PlayerController>().Ready == true)
            {
                mainChar.GetComponent<PlayerController>().CmdChuyenBuff();
                testImage.enabled = false;
                //GetComponent<BuffLogo>().enabled = false;
                //DoiPhuong.GetComponent<DameLogo>().enabled = false;
            }
        }
    }
}
