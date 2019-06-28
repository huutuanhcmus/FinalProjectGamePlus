using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
  
    private CharacterAnimations playerAnimations1;

    public GameObject AttackPoint2;
   
    public GameObject AttackPoint;
    
    public GameObject AttackPoint3;

    public GameObject AttackPoint4;
    public GameObject AttackPoint5;
    public GameObject AttackPoint6;
    public GameObject AttackPoint7;
    //private PlayerSkill3 shield;
    private CharacterSoundFX soundFX1;

    public int CDSkill1;
    public int CDSkill2;
    public int CDSkill3;
    public int CDSkill4;
    public int CDSkill5;
    public int CDSkilL6;
    public int CDSkill7;

    void Awake()
    {
        playerAnimations1 = GetComponent<CharacterAnimations>();
     

        soundFX1 = GetComponentInChildren<CharacterSoundFX>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerAnimations1.Attack1(true);
            soundFX1.Attack_1();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {      
            playerAnimations1.Attack2(true);
            soundFX1.Attack_2();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerAnimations1.Attack3(true);
            soundFX1.Attack_3();
           
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playerAnimations1.Attack4(true);
            soundFX1.Attack_4();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            playerAnimations1.Attack5(true);
            soundFX1.Attack_5();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            playerAnimations1.Attack6(true);
            soundFX1.Attack_6();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            playerAnimations1.Attack7(true);
            soundFX1.Attack_7();
        }
    }

    void Activate_AttackPoint()
    {
        AttackPoint.SetActive(true);

    }
    void Deactivate_AttackPoint()
    {
        if(AttackPoint.activeInHierarchy)

        {
            AttackPoint.SetActive(false);
        }
    }
    ///////////////////////////////////////////////////////////////////////////
    void Activate_AttackPoint2()
    {
        AttackPoint2.SetActive(true);

    }
    void Deactivate_AttackPoint2()
    {
        if (AttackPoint2.activeInHierarchy)

        {
            AttackPoint2.SetActive(false);
        }
    }
    ///////////////////////////////////////////////////////////////////////////
    void Activate_AttackPoint3()
    {
        AttackPoint3.SetActive(true);

    }
    void Deactivate_AttackPoint3()
    {
        if (AttackPoint3.activeInHierarchy)

        {
            AttackPoint3.SetActive(false);
        }
    }
    ///////////////////////////////////////////////////////////////////////////
    void Activate_AttackPoint4()
    {
        AttackPoint4.SetActive(true);

    }
    void Deactivate_AttackPoint4()
    {
        if (AttackPoint4.activeInHierarchy)

        {
            AttackPoint4.SetActive(false);
        }
    }
    ///////////////////////////////////////////////////////////////////////////
    void Activate_AttackPoint5()
    {
        AttackPoint5.SetActive(true);

    }
    void Deactivate_AttackPoint5()
    {
        if (AttackPoint5.activeInHierarchy)

        {
            AttackPoint5.SetActive(false);
        }
    }
    ///////////////////////////////////////////////////////////////////////////
    void Activate_AttackPoint6()
    {
        AttackPoint6.SetActive(true);

    }
    void Deactivate_AttackPoint6()
    {
        if (AttackPoint6.activeInHierarchy)

        {
            AttackPoint6.SetActive(false);
        }
    }
    ///////////////////////////////////////////////////////////////////////////
    void Activate_AttackPoint7()
    {
        AttackPoint7.SetActive(true);

    }
    void Deactivate_AttackPoint7()
    {
        if (AttackPoint7.activeInHierarchy)

        {
            AttackPoint7.SetActive(false);
        }
    }
    ///////////////////////////////////////////////////////////////////////////

}
