using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PheANCLogo : MonoBehaviour
{
    public RawImage testImage;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            testImage.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            testImage.enabled = false;
        }
    }
}
