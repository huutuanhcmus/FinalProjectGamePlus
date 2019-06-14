using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    [SyncVar] public float speed = 1.0f;
    public GameObject bullet;
    public GameObject Wall;
    public Transform bulletspawn;
    public Transform Wallspawn;
    public GameObject Stun;
    Animator playerAnimation;
    private Thread StunTimeCount;

    [SyncVar] public int Phe = 0;
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

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f * speed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f * speed;
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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Cmdfire();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CmdWall();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CmdStun();
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            CmdHKM();
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            CmdANC();
        }
    }
    
    

    [Command]
    void Cmdfire()
    {
        var bulletTemp = (GameObject)Instantiate(bullet, bulletspawn.position, bulletspawn.rotation);
        bulletTemp.GetComponent<Rigidbody>().velocity = bulletspawn.forward * 6;
        NetworkServer.Spawn(bulletTemp);
        bulletTemp.GetComponent<Bullet>().Phe = Phe;
    }

    [Command]
    void CmdWall()
    {
        var WallTemp = (GameObject)Instantiate(Wall, Wallspawn.position, Wallspawn.rotation);
        NetworkServer.Spawn(WallTemp);
    }

    [Command]
    void CmdStun()
    {
        var StunTemp = (GameObject)Instantiate(Stun, bulletspawn.position, bulletspawn.rotation);
        StunTemp.GetComponent<Rigidbody>().velocity = bulletspawn.forward * 6;
        NetworkServer.Spawn(StunTemp);
        StunTemp.GetComponent<Stun>().Phe = Phe;
    }


    [Command]
    public void CmdANC()
    {
        Phe = 2;
        //Destroy(transform.GetChild(3));
    }

    [Command]
    public void CmdHKM()
    {
        Phe = 1;
        //Destroy(transform.GetChild(3));
    }

    [Command]
    public void CmdStunPlayer(float time)
    {
        Debug.Log("3");
        speed = 0;
        float startTime = Time.time;
        StunTimeCount = new Thread(new ThreadStart(CmdcountTimeStun));
        StunTimeCount.Start();
    }

    [Command]
    void CmdcountTimeStun()
    {
        Thread.Sleep(3000);
        speed = 1;
    }


    public override void OnStartLocalPlayer()
    {
        Camera.main.GetComponent<CameraController>().setTarget(gameObject.transform);
        transform.position = new Vector3(-540.13f, 14.39f, 222.06f);
        base.OnStartLocalPlayer();
    }
}

