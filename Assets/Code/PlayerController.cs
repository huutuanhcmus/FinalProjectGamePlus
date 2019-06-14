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
    public Transform aoespawn;
    public Transform circleWallspawn;
    public GameObject Stun;
    public GameObject RemoveStun;
    public GameObject aoeSkill;
    public GameObject circleWall;
    public GameObject supperDame;
    private bool flag = false;
    Animator playerAnimation;
    Thread StunTimeCount;

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
        Debug.Log(z);
        if (z >= 0.01 || z <= -0.01)
        {
            playerAnimation.SetBool("walk", true);
            if (StunTimeCount != null)
            {
                Debug.Log("hello");
                StunTimeCount.Abort();
                StunTimeCount = null;
            }
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
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CmdRemoveStun();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            CmdAoeSkill();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            CmdCircleWall();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Debug.Log("vvv");
            CmdSupperDame(); //CmdSupperDame();
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            CmdHKM();
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            CmdANC();
        }
        Debug.Log("4");
        CmdPlaySupperDame();
    }
    
    

    [Command]
    void Cmdfire()
    {
        var bulletTemp = (GameObject)Instantiate(bullet, bulletspawn.position, bulletspawn.rotation);
        bulletTemp.GetComponent<Rigidbody>().velocity = bulletspawn.forward * 6;
        bulletTemp.GetComponent<Bullet>().Phe = Phe;
        NetworkServer.Spawn(bulletTemp);
    }

    [Command]
    void CmdWall()
    {
        var WallTemp = (GameObject)Instantiate(Wall, Wallspawn.position, Wallspawn.rotation);
        NetworkServer.Spawn(WallTemp);
    }

    [Command]
    void CmdCircleWall()
    {
        var CirCleWallTemp = (GameObject)Instantiate(circleWall, circleWallspawn.position, circleWallspawn.rotation);
        NetworkServer.Spawn(CirCleWallTemp);
    }

    [Command]
    void CmdStun()
    {
        var StunTemp = (GameObject)Instantiate(Stun, bulletspawn.position, bulletspawn.rotation);
        StunTemp.GetComponent<Rigidbody>().velocity = bulletspawn.forward * 6;
        StunTemp.GetComponent<Stun>().Phe = Phe;
        NetworkServer.Spawn(StunTemp);
    }

    [Command]
    void CmdRemoveStun()
    {
        var removeStunTemp = (GameObject)Instantiate(RemoveStun, transform.position, transform.rotation, transform);
        speed = 1;
        Destroy(removeStunTemp, 3);
        NetworkServer.Spawn(removeStunTemp);
    }

    [Command]
    void CmdAoeSkill()
    {
        var AoeSkillTemp = (GameObject)Instantiate(aoeSkill, aoespawn.transform.position, aoespawn.transform.rotation);
        AoeSkillTemp.GetComponent<AOESkill>().Phe = Phe;
        NetworkServer.Spawn(AoeSkillTemp);
    }

    [Command]
    void CmdSupperDame()
    {
        Debug.Log("0");
        StunTimeCount = new Thread(new ThreadStart(countTimeSupperDame));
        StunTimeCount.Start();
    }

    [Command]
    void CmdPlaySupperDame()
    {
        Debug.Log("3");
        if (flag)
        {
            var SupperDameTemp = (GameObject)Instantiate(supperDame, bulletspawn.position, bulletspawn.rotation);
            SupperDameTemp.GetComponent<Rigidbody>().velocity = bulletspawn.forward * 6;
            SupperDameTemp.GetComponent<Bullet>().Phe = Phe;
            NetworkServer.Spawn(SupperDameTemp);
            flag = false;
        }
    }

    void countTimeSupperDame()
    {
        Debug.Log("2");
        Thread.Sleep(2000);
        flag = true;
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
    }

    [Command]
    public void CmdStunPlayer(float speedFunc)
    {
        Debug.Log("3");
        speed = speedFunc;
        Thread StunTimeCount = new Thread(new ThreadStart(CmdcountTimeStun));
        StunTimeCount.Start();
    }

    public void CmdStunPlayerSlow(float speedFunc)
    {
        Debug.Log("3");
        speed = speedFunc;
        Thread StunTimeCount = new Thread(new ThreadStart(CmdcountTimeStunSlow));
        StunTimeCount.Start();
    }

    void CmdcountTimeStun()
    {
        Thread.Sleep(3000);
        speed = 1;
    }

    [Command]
    void CmdcountTimeStunSlow()
    {
        Thread.Sleep(5000);
        speed = 1;
    }

    public override void OnStartLocalPlayer()
    {
        Camera.main.GetComponent<CameraController>().setTarget(gameObject.transform);
        transform.position = new Vector3(-540.13f, 14.39f, 222.06f);
        base.OnStartLocalPlayer();
    }
}

