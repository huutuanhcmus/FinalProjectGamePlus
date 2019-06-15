using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DameLogo : MonoBehaviour
{
    public RawImage testImage;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            testImage.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            Debug.Log("vvvvvv");
            testImage.enabled = true;
        }
    }
}
