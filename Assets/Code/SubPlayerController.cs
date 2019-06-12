using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubPlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.parent.transform.position = new Vector3(-540.13f, 14.39f, 222.06f);
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        this.transform.parent.transform.Rotate(0, x, 0);
        this.transform.parent.transform.Translate(0, 0, z);

    }
}
