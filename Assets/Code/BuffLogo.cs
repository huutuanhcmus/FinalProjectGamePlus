using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffLogo : MonoBehaviour
{
    public RawImage testImage;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            testImage.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            testImage.enabled = false;
        }
    }
}
