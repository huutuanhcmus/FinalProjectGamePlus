using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public GameObject bullet;
    public Transform bulletspawn;
    Animator playerAnimation;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(-540.13f, 14.39f, 222.06f);
        playerAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        if (z >= 0.01)
        {
            playerAnimation.SetBool("walk", true);
        }
        else
        {
            playerAnimation.SetBool("walk", false);
        }
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Cmdfire();
        }
    }

    [Command]
    void Cmdfire()
    {
        var bulletTemp = (GameObject)Instantiate(bullet, bulletspawn.position, bulletspawn.rotation);
        bulletTemp.GetComponent<Rigidbody>().velocity = bulletTemp.transform.forward * 6;
        NetworkServer.Spawn(bulletTemp);
        Debug.Log("aaa");
        Destroy(bulletTemp, 1.0f);
    }

    public override void OnStartLocalPlayer()
    {
        Camera.main.GetComponent<CameraController>().setTarget(gameObject.transform);
        transform.position = new Vector3(-540.13f, 14.39f, 222.06f);
        base.OnStartLocalPlayer();
    }
}

