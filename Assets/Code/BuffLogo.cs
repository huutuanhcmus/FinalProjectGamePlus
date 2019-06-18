using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffLogo : MonoBehaviour
{
    public RawImage testImage;
    public GameObject DoiPhuong;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            testImage.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
            {
                if (go.name == "MainChar")
                {
                    go.GetComponent<PlayerController>().CmdChuyenBuff();
                }
            }
            testImage.enabled = false;
            GetComponent<BuffLogo>().enabled = false;
            DoiPhuong.GetComponent<DameLogo>().enabled = false;
        }
    }
}
