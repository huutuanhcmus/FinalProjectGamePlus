using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Information : MonoBehaviour
{
    public Canvas infor;
    // Start is called before the first frame update
    void Start()
    {
        infor.enabled = false;
    }

    public void showInfor()
    {
        infor.enabled = !infor.enabled;
    }
}
