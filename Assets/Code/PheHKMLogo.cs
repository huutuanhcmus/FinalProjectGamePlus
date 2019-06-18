using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PheHKMLogo : MonoBehaviour
{
    // Start is called before the first frame update
    public RawImage testImage;
    public Transform HKMPos;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
            {
                if (go.name == "MainChar")
                {
                    go.GetComponent<PlayerController>().CmdHKM();
                    go.GetComponent<Transform>().position = HKMPos.position;
                    break;
                }
            }
            testImage.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Debug.Log("vvvvvv");
            testImage.enabled = true;
        }
    }
}
