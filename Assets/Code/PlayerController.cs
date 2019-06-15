﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
//using static System.Net.Mime.MediaTypeNames;

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
    public bool flag = false;
    Animator playerAnimation;
    Thread StunTimeCount;
    Thread BeaseSkillThread;
    Thread WallSkillThread;
    Thread CircleWallSkillThread;
    Thread StunSkillThread;
    Thread RemoveStunSkillThread;
    Thread AOESkillThread;
    Thread SupperDameSkillThread;
    Thread TwoSecon;
    public Text textBaseSkill;
    public Text textWallSkill;
    public Text textStunSkill;
    public Text textRemoveStunSkill;
    public Text textCircleWallSkill;
    public Text textAOESkill;
    public Text textSuperDameSkill;
    public bool flagBaseDameSkill = false;
    public bool flagWallSkill = false;
    public bool flagStunSkill = false;
    public bool flagRemoveStunDameSkill = false;
    public bool flagCircleWallSkill = false;
    public bool flagAOESkill = false;
    public bool flagSuperDameSkill = false;
    public List<Text> gos;
    public int manaBaseDameSkill;
    public int manaWallSkill;
    public int manaStunSkill;
    public int manaRemoveStun;
    public int manaCircleWall;
    public int manaAOESkill;
    public int manaSuperDameSkill;
    public bool flagTemp = false;
    public bool flagTemp2 = false;
    [SyncVar] public int Phe = 0;
    public bool walk = false;
    public bool flagPush = false;
    Thread HoiMau;
    public bool flagVanCong = true;
    public List<GameObject> Players;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(-540.13f, 14.39f, 222.06f);
        playerAnimation = GetComponent<Animator>();
        gos = new List<Text>();
        foreach (Text go in Resources.FindObjectsOfTypeAll(typeof(Text)))
        {
            if (go.name == "CDBaseDame")
                textBaseSkill = go;
            else if (go.name == "CDWallSkill")
                textWallSkill = go;
            else if (go.name == "CDStunSkill")
                textStunSkill = go;
            else if (go.name == "CDRemoveStun")
                textRemoveStunSkill = go;
            else if (go.name == "CDCircleWall")
                textCircleWallSkill = go;
            else if (go.name == "CDAOESkill")
                textAOESkill = go;
            else if (go.name == "CDSuperDame")
                textSuperDameSkill = go;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (flagBaseDameSkill)
            textBaseSkill.text = ConvertTime(CDBaseSkill);
        else
            textBaseSkill.text = "";
        if (flagWallSkill)
            textWallSkill.text = ConvertTime(CDWallSkill);
        else
            textWallSkill.text = "";
        if (flagStunSkill)
            textStunSkill.text = ConvertTime(CDStunSkill);
        else
            textStunSkill.text = "";
        if (flagRemoveStunDameSkill)
            textRemoveStunSkill.text = ConvertTime(CDRemoveStunSkill);
        else
            textRemoveStunSkill.text = "";
        if (flagCircleWallSkill)
            textCircleWallSkill.text = ConvertTime(CDCircleWallSkill);
        else
            textCircleWallSkill.text = "";
        if (flagAOESkill)
            textAOESkill.text = ConvertTime(CDAOESKill);
        else
            textAOESkill.text = "";
        if (flagSuperDameSkill)
            textSuperDameSkill.text = ConvertTime(CDSupperDameSkill);
        else
            textSuperDameSkill.text = "";
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f * speed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f * speed;
        Debug.Log(z);
        if (z >= 0.01 || z <= -0.01)
        {
            playerAnimation.SetBool("walk", true);
            if (TwoSecon != null)
            {
                Debug.Log("hello");
                TwoSecon.Abort();
                TwoSecon = null;
            }
            if(HoiMau != null)
            {
                HoiMau.Abort();
                HoiMau = null;
            }
            flagVanCong = true;
        }
        else
        {
            playerAnimation.SetBool("walk", false);
        }
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (GetComponent<Mancharacter>().getManaCurrent() >= manaBaseDameSkill)
            {
                if (flagBaseDameSkill == false)
                {
                    GetComponent<Mancharacter>().CmdTakeMana(manaBaseDameSkill);
                    flagBaseDameSkill = true;
                    CDBaseSkill = 3;
                    Cmdfire();
                    BeaseSkillThread = new Thread(new ThreadStart(countTimeBaseSkill));
                    BeaseSkillThread.Start();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (GetComponent<Mancharacter>().getManaCurrent() >= manaWallSkill)
            {
                if (flagWallSkill == false)
                {
                    GetComponent<Mancharacter>().CmdTakeMana(manaWallSkill);
                    flagWallSkill = true;
                    CDWallSkill = 30;
                    CmdWall();
                    WallSkillThread = new Thread(new ThreadStart(countTimeWallSkill));
                    WallSkillThread.Start();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (GetComponent<Mancharacter>().getManaCurrent() >= manaStunSkill)
            {
                if (flagStunSkill == false)
                {
                    GetComponent<Mancharacter>().CmdTakeMana(manaStunSkill);
                    flagStunSkill = true;
                    CDStunSkill = 15;
                    CmdStun();
                    StunSkillThread = new Thread(new ThreadStart(countStunSkill));
                    StunSkillThread.Start();
                }

            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (GetComponent<Mancharacter>().getManaCurrent() >= manaRemoveStun)
            {
                if (flagRemoveStunDameSkill == false)
                {
                    GetComponent<Mancharacter>().CmdTakeMana(manaRemoveStun);
                    flagRemoveStunDameSkill = true;
                    CDRemoveStunSkill = 25;
                    CmdRemoveStun();
                    RemoveStunSkillThread = new Thread(new ThreadStart(countRemoveStunSkill));
                    RemoveStunSkillThread.Start();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (GetComponent<Mancharacter>().getManaCurrent() >= manaAOESkill)
            {
                if (flagAOESkill == false)
                {
                    GetComponent<Mancharacter>().CmdTakeMana(manaAOESkill);
                    flagAOESkill = true;
                    CDAOESKill = 15;
                    CmdAoeSkill();
                    AOESkillThread = new Thread(new ThreadStart(countAOESkill));
                    AOESkillThread.Start();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (GetComponent<Mancharacter>().getManaCurrent() >= manaCircleWall)
            {
                if (flagCircleWallSkill == false)
                {
                    GetComponent<Mancharacter>().CmdTakeMana(manaCircleWall);
                    flagCircleWallSkill = true;
                    CDCircleWallSkill = 30;
                    CmdCircleWall();
                    CircleWallSkillThread = new Thread(new ThreadStart(countTimeCircleWallSkill));
                    CircleWallSkillThread.Start();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (GetComponent<Mancharacter>().currentMana >= manaSuperDameSkill)
            {
                Debug.Log("3");
                if (flagSuperDameSkill == false && flagVanCong == true)
                {
                    flagVanCong = false;
                    Debug.Log("4");
                    GetComponent<Mancharacter>().CmdTakeMana(manaSuperDameSkill);
                    CDSupperDameSkill = 15;
                    TwoSecon = new Thread(new ThreadStart(countTimeSupperDame));
                    TwoSecon.Start();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            HoiMau = new Thread(new ThreadStart(PushHealth));
            HoiMau.Start();
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
        PlaySupperDame();
        HoiMauChar();
        ChangeColorPlayer();
    }

    void ChangeColorPlayer()
    {
        Players = new List<GameObject>();
        foreach (GameObject Player in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
        {
            if (Player.tag == "Player")
            {
                
                if(Player.GetComponent<PlayerController>().Phe != Phe)
                {
                    Debug.Log(Phe);
                    Debug.Log((Player.GetComponent<PlayerController>().Phe));
                    Player.GetComponent<Transform>().GetChild(7).GetChild(0).GetComponent<ParticleSystem>().startColor = Color.red;
                    Player.GetComponent<Transform>().GetChild(7).GetComponent<ParticleSystem>().startColor = Color.red;
                }
                else
                {
                    Player.GetComponent<Transform>().GetChild(7).GetChild(0).GetComponent<ParticleSystem>().startColor = new Color(255,255,0);
                    Player.GetComponent<Transform>().GetChild(7).GetComponent<ParticleSystem>().startColor = new Color(255, 255, 0);
                }
            }
        }

    }

    void HoiMauChar()
    {
        if(flagPush == true)
        {
            GetComponent<Health>().CmdPushHealth(10);
            GetComponent<Mancharacter>().CmdPushMana(10);
            flagPush = false;
        }
    }

    void PushHealth()
    {
        while (true)
        {
            Thread.Sleep(5000);
            flagPush = true;
        }
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
    void CmdCreateSuperDame()
    {
        var SupperDameTemp = (GameObject)Instantiate(supperDame, bulletspawn.position, bulletspawn.rotation);
        SupperDameTemp.GetComponent<Rigidbody>().velocity = bulletspawn.forward * 6;
        SupperDameTemp.GetComponent<Bullet>().Phe = Phe;
        NetworkServer.Spawn(SupperDameTemp);
    }
    void PlaySupperDame()
    {
        if (flag)
        {
            flag = false;
            flagSuperDameSkill = true;
            SupperDameSkillThread = new Thread(new ThreadStart(countSuperSkillSkill));
            SupperDameSkillThread.Start();
            CmdCreateSuperDame();
        }
    }

    void countTimeSupperDame()
    {
        Debug.Log("2");
        Thread.Sleep(2000);
        flagVanCong = true;
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
        name = "MainChar";
        Camera.main.GetComponent<CameraController>().setTarget(gameObject.transform);
        transform.position = new Vector3(-540.13f, 14.39f, 222.06f);
        base.OnStartLocalPlayer();
    }

    void countTimeBaseSkill()
    {
       for(int i = CDBaseSkill; i >= 0; i--) { 
            Thread.Sleep(1000);
            CDBaseSkill--;
       }
        flagBaseDameSkill = false;
    }
    void countTimeWallSkill()
    {
        for (int i = CDWallSkill; i >= 0; i--)
        {
            Thread.Sleep(1000);
            CDWallSkill--;
        }
        flagWallSkill = false;
    }
    void countTimeCircleWallSkill()
    {
        for (int i = CDCircleWallSkill; i >= 0; i--)
        {
            Thread.Sleep(1000);
            CDCircleWallSkill--;
        }
        flagCircleWallSkill = false;
    }
    void countStunSkill()
    {
        for (int i = CDStunSkill; i >= 0; i--)
        {
            Thread.Sleep(1000);
            CDStunSkill--;           
        }
        flagStunSkill = false;
    }
    void countRemoveStunSkill()
    {
        for (int i = CDRemoveStunSkill; i >= 0; i--)
        {
            Thread.Sleep(1000);
            CDRemoveStunSkill--;
        }
        flagRemoveStunDameSkill = false;
    }
    void countAOESkill()
    {
        for (int i = CDAOESKill; i >= 0; i--)
        {
            Thread.Sleep(1000);
            CDAOESKill--;
        }
        flagAOESkill = false;
    }
    void countSuperSkillSkill()
    {
        for (int i = CDSupperDameSkill; i >= 0; i--)
        {
            Thread.Sleep(1000);
            CDSupperDameSkill--;
        }
        flagSuperDameSkill = false;
    }
    private string ConvertTime(int second)
    {
        TimeSpan t = TimeSpan.FromSeconds(second);
        // Converts the total miliseconds to the human readable time format
        if (t.Minutes != 0)
        {
            return t.Minutes.ToString() + "m";
        }
        else
        {
            return t.Seconds.ToString();
        }
    }
}

