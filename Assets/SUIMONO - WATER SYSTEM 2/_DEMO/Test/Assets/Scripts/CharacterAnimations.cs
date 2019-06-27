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
    void FreezeAnimation()
    {
        anim.speed = 0f;
    }
    public void UnFreezeAnimation()
    {
        anim.speed = 1f;
    }
}
