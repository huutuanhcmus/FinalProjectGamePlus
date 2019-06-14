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
    public int CDBaseSkill;
    public int CDWallSkill;
    public int CDCircleWallSkill;
    public int CDStunSkill;
    public int CDRemoveStunSkill;
    public int CDAOESKill;
    public int CDSupperDameSkill;
    private bool flag = false;
    Animator playerAnimation;
    Thread StunTimeCount;
    Thread BeaseSkillThread;
    Thread WallSkillThread;
    Thread CircleWallSkillThread;
    Thread StunSkillThread;
    Thread RemoveStunSkillThread;
    Thread AOESkillThread;
    Thread SupperDameSkillThread;

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
            if (CDBaseSkill == 0)
            {
                CDBaseSkill = 3;
                Cmdfire();
                BeaseSkillThread = new Thread(new ThreadStart(countTimeBaseSkill));
                BeaseSkillThread.Start();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (CDWallSkill == 0)
            {
                CDWallSkill = 30;
                CmdWall();
                WallSkillThread = new Thread(new ThreadStart(countTimeWallSkill));
                WallSkillThread.Start();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (CDStunSkill == 0)
            {
                CDStunSkill = 15;
                CmdStun();
                StunSkillThread = new Thread(new ThreadStart(countStunSkill));
                StunSkillThread.Start();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (CDRemoveStunSkill == 0)
            {
                CDRemoveStunSkill = 25;
                CmdRemoveStun();
                RemoveStunSkillThread = new Thread(new ThreadStart(countRemoveStunSkill));
                RemoveStunSkillThread.Start();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (CDAOESKill == 0)
            {
                CDAOESKill = 15;
                CmdAoeSkill();
                AOESkillThread = new Thread(new ThreadStart(countAOESkill));
                AOESkillThread.Start();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (CDCircleWallSkill == 0)
            {
                CDCircleWallSkill = 30;
                CmdCircleWall();
                CircleWallSkillThread = new Thread(new ThreadStart(countTimeCircleWallSkill));
                CircleWallSkillThread.Start();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (CDSupperDameSkill == 0)
            {
                CDSupperDameSkill = 15;
                CmdSupperDame();
                SupperDameSkillThread = new Thread(new ThreadStart(countTimeSupperDame));
                SupperDameSkillThread.Start();
            }
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

    void countTimeBaseSkill()
    {
       for(int i = CDBaseSkill; i > 0; i--) { 
            Thread.Sleep(1000);
            CDBaseSkill--;
       }
    }
    void countTimeWallSkill()
    {
        for (int i = CDWallSkill; i > 0; i--)
        {
            Thread.Sleep(1000);
            CDWallSkill--;
        }
    }
    void countTimeCircleWallSkill()
    {
        for (int i = CDCircleWallSkill; i > 0; i--)
        {
            Thread.Sleep(1000);
            CDCircleWallSkill--;
        }
    }
    void countStunSkill()
    {
        for (int i = CDStunSkill; i > 0; i--)
        {
            Thread.Sleep(1000);
            CDStunSkill--;
        }
    }
    void countRemoveStunSkill()
    {
        for (int i = CDRemoveStunSkill; i > 0; i--)
        {
            Thread.Sleep(1000);
            CDRemoveStunSkill--;
        }
    }
    void countAOESkill()
    {
        for (int i = CDAOESKill; i > 0; i--)
        {
            Thread.Sleep(1000);
            CDAOESKill--;
        }
    }
    void countSuperSkillSkill()
    {
        for (int i = CDSupperDameSkill; i > 0; i--)
        {
            Thread.Sleep(1000);
            CDSupperDameSkill--;
        }
    }
}

