using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
  
    private CharacterAnimations playerAnimations1;
    public GameObject AttackPoint;
    private PlayerSkill3 shield;
    private CharacterSoundFX soundFX1;
    void Awake()
    {
        playerAnimations1 = GetComponent<CharacterAnimations>();
        shield = GetComponent<PlayerSkill3>();

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
            shield.ActivateShield(true);
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
}
