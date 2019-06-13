using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PheHKMLogo : MonoBehaviour
{
    // Start is called before the first frame update
    public RawImage testImage;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            testImage.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Debug.Log("vvvvvv");
            testImage.enabled = true;
        }
    }
}
