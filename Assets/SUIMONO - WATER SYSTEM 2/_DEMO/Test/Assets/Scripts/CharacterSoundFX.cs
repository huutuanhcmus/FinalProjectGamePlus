using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterSoundFX : MonoBehaviour
{

    private AudioSource soundFX;

    [SerializeField]
    private AudioClip attack_Sound_1,
                      attack_Sound_2,
                      attack_Sound_3,
                      attack_Sound_4,
                      attack_Sound_5,
                      attack_Sound_6,
                      attack_Sound_7,
                      Die_Sound;




    void Awake()
    {
        soundFX = GetComponent<AudioSource>();
    }
    public void Attack_1()
    {
        soundFX.clip = attack_Sound_1;
        soundFX.Play();
    }
    public void Attack_2()
    {
        soundFX.clip = attack_Sound_2;
        soundFX.Play();
    }
    public void Attack_3()
    {
        soundFX.clip = attack_Sound_3;
        soundFX.Play();
    }
    public void Attack_4()
    {
        soundFX.clip = attack_Sound_4;
        soundFX.Play();
    }
    public void Attack_5()
    {
        soundFX.clip = attack_Sound_5;
        soundFX.Play();
    }
    public void Attack_6()
    {
        soundFX.clip = attack_Sound_6;
        soundFX.Play();
    }
    public void Attack_7()
    {
        soundFX.clip = attack_Sound_7;
        soundFX.Play();
    }
    public void Die()
    {
        soundFX.clip = Die_Sound;
        soundFX.Play();
    }
    // Update is called once per frame

    
}
