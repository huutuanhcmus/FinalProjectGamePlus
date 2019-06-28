using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    private Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Walk(bool walk)
    {
        anim.SetBool(AnimationTags.WALK_PARATEMER, walk);
    }
    public void Defend(bool defend)
    {
        anim.SetBool(AnimationTags.DEFEND_PARATEMER, defend);
    }
    public void Attack1(bool attack1)
    {
        anim.SetBool(AnimationTags.ATTACK1_PARATEMER, attack1);
    }
    public void Attack2(bool attack2)
    {
        anim.SetBool(AnimationTags.ATTACK2_PARATEMER, attack2);
    }
    public void Attack3(bool attack3)
    {
        anim.SetBool(AnimationTags.ATTACK3_PARATEMER, attack3);
    }
    public void Attack4(bool attack4)
    {
        anim.SetBool(AnimationTags.ATTACK4_PARATEMER, attack4);
    }
    public void Attack5(bool attack5)
    {
        anim.SetBool(AnimationTags.ATTACK5_PARATEMER, attack5);
    }
    public void Attack6(bool attack6)
    {
        anim.SetBool(AnimationTags.ATTACK6_PARATEMER, attack6);
    }
    public void Attack7(bool attack7)
    {
        anim.SetBool(AnimationTags.ATTACK7_PARATEMER, attack7);
    }
    //public void Die(bool Die)
    //{
    //    anim.SetBool(AnimationTags.Die_PARATEMER, Die);
    //}
    void FreezeAnimation()
    {
        anim.speed = 0f;
    }
    public void UnFreezeAnimation()
    {
        anim.speed = 1f;
    }
}
