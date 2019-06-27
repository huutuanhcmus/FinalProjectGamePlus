using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
  
    private CharacterAnimations playerAnimations1;
    public GameObject attackPoint;
    void Awake()
    {
        playerAnimations1 = GetComponent<CharacterAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerAnimations1.Attack1(true);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {      
                playerAnimations1.Attack2(true);         
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerAnimations1.Attack3(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playerAnimations1.Attack4(true);
        }
    }

    void Activate_AttackPoint()
    {
        attackPoint.SetActive(true);

    }
    void Deactivate_AttackPoint()
    {
        if(attackPoint.activeInHierarchy)

        {
            attackPoint.SetActive(false);
        }
    }
}
