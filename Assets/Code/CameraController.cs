using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float x = -0.03f;
    public float y = 0.47f;
    public float z = -2.49f;
    public float m = 1.18f;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        x = 0.04f;
        y = 1.22f;
        z = -2.22f;
        m = 1.18f;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            //transform.position = playerTransform.position + new Vector3(playerTransform.localRotation.x, playerTransform.localRotation.y, playerTransform.localRotation.z-5F);//new Vector3(0.4f,-3);
            transform.position = playerTransform.TransformPoint(new Vector3(x, y, z));
            //transform.position = new Vector3(transform.position.x, transform.position.y + m, transform.position.z);
            transform.LookAt(new Vector3(playerTransform.position.x, playerTransform.position.y + m, playerTransform.position.z));
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
        {
            if(z < -1.3)
                z += Time.deltaTime*5;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
        {
            if (z > -6)
                z -= Time.deltaTime*5;
        }
    }

    public void setTarget(Transform target)
    {
        Debug.Log("Tuan");
        playerTransform = target;
    }
}
