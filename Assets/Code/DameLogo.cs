using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DameLogo : MonoBehaviour
{
    public RawImage testImage;
    public GameObject DoiPhuong;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
            {
                if (go.name == "MainChar")
                {
                    go.GetComponent<PlayerController>().CmdChuyenDame();
                }
            }
            testImage.enabled = false;
            GetComponent<DameLogo>().enabled = false;
            DoiPhuong.GetComponent<BuffLogo>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            testImage.enabled = true;
        }
    }
}
